    [ValueConversion(typeof(double), typeof(double))]
    public class MyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var total = (double)values.FirstOrDefault();
            var subtract = values.Cast<double>().Sum();
            return total + total - subtract;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
