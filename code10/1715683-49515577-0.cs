    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ComboBoxItem cbi = value as ComboBoxItem;
            if (cbi != null)
                return cbi.Tag;
            return value;
        }
    }
