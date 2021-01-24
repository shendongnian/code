    public class MultiplyColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var baseColor = ((SolidColorBrush)values[0]).Color;
            var factor = (float)values[1];
            return new SolidColorBrush(Color.Multiply(baseColor, factor));
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
