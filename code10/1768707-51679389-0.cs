    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double originalValue = System.Convert.ToDouble(value);
            double multiplier = System.Convert.ToDouble(parameter);
    
            return originalValue * multiplier;
        }
    
        public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
