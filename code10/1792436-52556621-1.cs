    public class BoolToVisible:IValueConverter
    {
    
    public BoolToVisible()
    {
        
    }
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var val=(bool)value;
        if (parameter?.ToString() == "1")
        {
            val=!val;
        }
        if (val)
        {
            return Visibility.Visible;
        }else
            return Visibility.Collapsed;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
