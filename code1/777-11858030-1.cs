    public class IntegerFormatConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int result;
            int.TryParse(value.ToString(), out result);
            return result;
        }
    
        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int result;
            int.TryParse(value.ToString(), out result);
            return result;
        }
    }
