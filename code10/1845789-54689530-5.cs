    public class PartColorValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = value as bool[] ?? new bool[] { };
            var i = System.Convert.ToInt32(parameter);
            return b.ElementAtOrDefault(i) ? Brushes.Red : Brushes.Black;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
