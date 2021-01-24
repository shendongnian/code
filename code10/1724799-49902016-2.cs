    public class DecimalToStringConverter : IValueConverter
    {
        private string _lastConvertedValue;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _lastConvertedValue ?? value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value?.ToString();
            decimal d;
            if (decimal.TryParse(str, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out d))
            {
                _lastConvertedValue = str;
                return d;
            }
            _lastConvertedValue = null;
            return Binding.DoNothing;
        }
    }
