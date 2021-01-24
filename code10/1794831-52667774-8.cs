    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Data;
    
    namespace OneWayTwoWayBinding
    {
        public class Converters : IValueConverter
        {
           public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
           {
                //value = 5; //ta liczba pojawi sie w textbox po uruchomieniu aplikacji
                return value;
           }
           public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
           {
            if (string.IsNullOrEmpty(value.ToString()))
                return null;
                //int var;
                //var = int.Parse(value.ToString());
                //var *= 2;
                //value = var;
            return value; //liczba wpisana w textbox z poziomu widoku aplikacji
           }
        }
        public class ConverterFiltering : IMultiValueConverter
        {
            public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value[0] == DependencyProperty.UnsetValue || value[1] == DependencyProperty.UnsetValue)
                {
                    return value[0];
                }
                return value[0];
            }
            public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
            {
                string[] values = new string[2];
                values[0] = value.ToString();
                values[1] = value.ToString();
                return values;
            }
        }
        public class ConverterButton : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                string _employeeName = (string)values[0];
                //MessageBox.Show("ButtonConverter: " + _employeeName);
                return string.Format("{0}", _employeeName);
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
