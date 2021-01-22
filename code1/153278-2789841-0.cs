    public class EnumToVisibilityConverter : IValueConverter 
    { 
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) 
        { 
            if (Enum.GetName(value.GetType(), value).Equals(parameter)) 
                return Visibility.Visible; 
            else 
                return Visibility.Hidden; 
        } 
     
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) 
        { 
            return null; 
        } 
    } 
