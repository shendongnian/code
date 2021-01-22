    public class ZeroConverter : IValueConverter {
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format(culture, "{0:0.00;-0.00;#}", value);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value as string;
            if (!String.IsNullOrEmpty(str)) {
                return System.Convert.ChangeType(str, targetType, culture);
            }
            return System.Convert.ChangeType(0, targetType, culture);
        }
    
    }
