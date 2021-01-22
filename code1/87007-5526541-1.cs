    public class BooleanToVisibilityConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		bool param = bool.Parse(value.ToString());
    		if (param == true)
    			return Visibility.Visible;
    		else
    			return Visibility.Collapsed;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    }
