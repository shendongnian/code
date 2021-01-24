    public class BoolConverter : System.Windows.Data.IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		if (value is bool)
    		{
    			return value.ToString();
    		}
    		return null;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    }
