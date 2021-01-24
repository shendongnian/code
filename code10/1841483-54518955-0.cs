    public class TestConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ClassExample obj = value as ClassExample;
            if (obj != null)
            {
                return obj.X;
            }
            return 0;
        }
    }
