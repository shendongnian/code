    public class BoolToSolColBrushConverter : IValueConverter
    {
    	private static SolidColorBrush changedBr = new SolidColorBrush(Colors.Red);
    	private static SolidColorBrush unchangedBr = new SolidColorBrush(Colors.Green);
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		try
    		{
    			if ((bool)value)
    			{
    				return unchangedBr;
    			}
    
    		}
    		catch (Exception)
    		{
    		}
    		return changedBr;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
