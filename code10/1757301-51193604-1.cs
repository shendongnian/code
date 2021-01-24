    public class VisibilityInverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Visibility.Hidden;
    
            if (value == Visibility.Visible)
                return Visibility.Hidden;
    
            return Visibility.Visible;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, ultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
