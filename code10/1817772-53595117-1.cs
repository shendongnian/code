        public class PrefixConverter : IValueConverter
        {
            public string Prefix { get; set; }
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return Prefix + value?.ToString();
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
