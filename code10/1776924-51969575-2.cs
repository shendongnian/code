    public class LengthToBrush : IValueConverter
    {
        private const int _colorBorders = 0;
        private const int _pow = 2;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var stringValue = value as String;
            if (stringValue == null || stringValue.Length <=32) return new SolidColorBrush(Colors.Black);
            return new SolidColorBrush(Colors.Red);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
