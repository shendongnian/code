    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;
    namespace WpfApp1
    {
        class MultiValueConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (values.Contains(Visibility.Collapsed))
                {
                    return Visibility.Collapsed;
                }
                if (values.Contains(Visibility.Hidden))
                {
                    return Visibility.Hidden;
                }
                return Visibility.Visible;
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
    
