    public class NullValueToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                              CultureInfo culture)
        {
            return (value != null ? Visibility.Visible : Visibility.Collapsed);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter,  
                                  CultureInfo culture)
        {
            return null; // this shouldn't ever happen, since 
                         // you'll need to ensure one-way binding
        }
    }
