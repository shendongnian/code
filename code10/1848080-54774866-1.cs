    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double total = 0.0d;
                foreach (var item in value.ToString().Split(';'))
                    total += System.Convert.ToDouble(item.Trim());
                return total;
            }
            catch
            {
                return 0.0d;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
