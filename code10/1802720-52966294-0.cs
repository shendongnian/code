    public class ColumnWidthConverter : IValueConverter
    {
    	public object Convert(
    		object value, 
    		Type targetType, 
    		object parameter, 
    		System.Globalization.CultureInfo culture)
    	{            
    		var isVisible = (bool) value;
    		var width = parameter as string;           
    
    		return isVisible ? width : "0.0";            
    	}
    
    
    	public object ConvertBack(
    		object value, 
    		Type targetType, 
    		object parameter, 
    		System.Globalization.CultureInfo culture)
    	{
    		return Binding.DoNothing;
    	}
    
    }
