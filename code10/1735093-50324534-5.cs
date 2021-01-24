    public class TextConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		return System.Convert.ToString(value).Split('#').First();
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		return new NotImplementedException();
    	}
    }
    public class ColorConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    	var val = System.Convert.ToString(value).Split('#').Last();
    
    		//YOUR COLOR CONDITIONS HERE. I AM RETURNING SIMPLE ONE COLOR
    
    		return new SolidColorBrush(Colors.Red);
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		return new NotImplementedException();
    	}
    }
