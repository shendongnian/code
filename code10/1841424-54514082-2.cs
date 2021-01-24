    public class MultiEvaluator : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var value in values)
            {
                if (!System.Convert.ToBoolean(value))
                {
                    return Brushes.Red;
                }
            }
            return Brushes.Black;
        } 
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
