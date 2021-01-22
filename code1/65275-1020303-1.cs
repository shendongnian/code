    public class RoleToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var principal = value as Principal;
            if(principal != null) {
                return principal.IsInRole((string)parameter) ? Visibility.Visible : Visibility.Collapsed;
            }
    
            return null;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
             throw new NotImplementedException();
        }
    }
