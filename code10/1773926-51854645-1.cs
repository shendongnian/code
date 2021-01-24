    using System;
    using System.Globalization;
    using System.Windows.Data;
    namespace SO_app.Converters
    {
        public class DebugConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (null == value) {
                    return null;
                }
                // For a more sophisticated converter, check also the targetType and react accordingly..
                if (value is Color) {
                    Color color = (Color)value;
                    return new SolidColorBrush(color);
                }
                // You can support here more source types if you wish
                // For the example I throw an exception
                Type type = value.GetType();
                throw new InvalidOperationException("Unsupported type ["+type.Name+"]");  
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value;
            }
        }
    }  
