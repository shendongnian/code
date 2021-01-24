    public class MultValConverter : IMultiValueConverter
    {
    	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    	{
    		if (values.Length > 1 && values[0] is ICollection myCol)
    		{
    			var retVal = string.Empty;
    			var firstelem = true;
    			foreach (var item in myCol)
    			{
    				retVal += $"{(firstelem?string.Empty:", ")}{item}";
    				firstelem = false;
    			}
    				
    			return retVal;
    		}
    		else
    			return Binding.DoNothing;
    	}
    
    	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException("It's a one way converter.");
    	}
    }
