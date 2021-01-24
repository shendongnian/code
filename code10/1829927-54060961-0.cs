    public class StringListToStringConverter : IValueConverter
    {
        public object Convert(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Join(",", (IEnumerable<string>)value);
        }
        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new List<string>(((string)value).Split(','));
        }
    }
