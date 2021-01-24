    public class ColorToSolidColorBrushConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Color color)
                return new SolidColorBrush(color);
            return DefaultValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var brush = value as SolidColorBrush;
            return brush?.Color;
        }
        public SolidColorBrush DefaultValue { get; } = Brushes.Fuchsia;
    }
