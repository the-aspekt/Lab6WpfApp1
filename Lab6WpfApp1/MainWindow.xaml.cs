using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab6WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    enum Weather
    {
        sunny,
        cloudy,
        rainy,
        snowy
    };

    class WeatherControl : DependencyObject
    {
        public WeatherControl(int temperature, string windDirection, int windSpeed, Weather weather)
        {
            this.Temperature = temperature;
            this.WindSpeed = windSpeed;
            this.WindDirection = windDirection;
        }

        //private enum weather;

        public static readonly DependencyProperty TemperatureProperty;
        public static readonly DependencyProperty WindDirectionProperty;
        public static readonly DependencyProperty WindSpeedProperty;
        // public static readonly DependencyProperty WeatherProperty;

        private int temperature;
        private string windDirection;
        private int windSpeed;
       

        public int Temperature 
        {
            get => (int)GetValue(TemperatureProperty); 
            set => SetValue(TemperatureProperty, value); 
        }

        public string WindDirection
        {
            get => (string)GetValue(WindDirectionProperty);
            set => SetValue(WindDirectionProperty, value);
        }
        public int WindSpeed
        {
            get => (int)GetValue(WindSpeedProperty);
            set => SetValue(WindSpeedProperty, value);
        }
       
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
            WindDirectionProperty = DependencyProperty.Register(
                nameof(WindDirection),
                typeof(string),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceWindDirection)),
                new ValidateValueCallback(ValidateWindDirection));
            WindSpeedProperty = DependencyProperty.Register(
               nameof(WindSpeed),
               typeof(int),
               typeof(WeatherControl),
               new FrameworkPropertyMetadata(
                   0,
                   FrameworkPropertyMetadataOptions.AffectsMeasure |
                   FrameworkPropertyMetadataOptions.AffectsRender,
                   null,
                   new CoerceValueCallback(CoerceWindSpeed)),
               new ValidateValueCallback(ValidateWindSpeed));
        }
        private static bool ValidateWindDirection(object value)
        {
            string v = (string)value;
            if ( v.Length > 0)
            {
                return true;
            }
            else
                return false;
        }

        private static object CoerceWindDirection(DependencyObject d, object value)
        {
            try
            {
                string v = (string)value;
                return v;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Невозможно преобразовать направление ветра к строке" + ex.ToString());
                return null;
            }
        }

        private static bool ValidateWindSpeed(object value)
        {
            int v = (int)value;
            if (Math.Abs(v) <= 200)
            {
                return true;
            }
            else
                return false;
        }

        private static object CoerceWindSpeed(DependencyObject d, object value)
        {
            try
            {
                int v = (int)value;
                return v;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Невозможно преобразовать скорость ветра к числу" + ex.ToString());
                return null;
            }
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (Math.Abs(v) <= 50)
            {
                return true;
            }
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object value)
        {
            try
            {
                int v = (int)value;
                return v;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Невозможно преобразовать температуру к числу" + ex.ToString());
                return null;
            }
        }


    }

}
