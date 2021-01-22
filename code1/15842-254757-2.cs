    namespace YourProject
    {
        public class MultiplyConverter : System.Windows.Data.IValueConverter
        {
            public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return AsDouble(value)* AsDouble(parameter);
            }
            double AsDouble(object value)
            {
                var valueText = value as string;
                if (valueText != null)
                    return double.Parse(valueText);
                else
                    return (double)value;
            }
    
            public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new System.NotSupportedException();
            }
        }
    }
