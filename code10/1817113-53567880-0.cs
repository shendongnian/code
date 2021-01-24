    public class BooleanToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(string) && value is bool?)
            {
                var b = (bool?)value;
                if (!b.HasValue)
                    return "not available";
                return b.Value ? "yes" : "no";
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // implement it if you need two-way binding
            throw new NotImpementedException();
        }
    }
