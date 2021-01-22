    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    namespace WPFControls
    {
        class ShadowConverter:IMultiValueConverter
        {
            #region Implementation of IMultiValueConverter
    
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                var text = (string) values[0];
                return text == string.Empty
                           ? Visibility.Visible
                           : Visibility.Collapsed;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                return new object[0];
            }
    
            #endregion
        }
    }
