    public class MyMultiCurrencyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Aggregate((a, b) => $"{a} {b}");
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var toReturn = value.ToString().Split(' ');
            return toReturn;
        }
    }
