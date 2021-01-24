    public class FlagConverter : MarkupExtension, IValueConverter
    {
        private int _mask;
        private int _targetValue;
        public FlagConverter(object enumValue)
        {
            _mask = (int)enumValue;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            _targetValue = (int)value;
            return ((_mask & _targetValue) != 0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            _targetValue ^= _mask;
            return Enum.Parse(targetType, _targetValue.ToString());
        }
    }
