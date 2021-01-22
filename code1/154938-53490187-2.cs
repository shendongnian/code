    class System.Convert
    {
    	public static string ToString(object value)
    	{
    		return value.ToString(CultureInfo.CurrentCulture);
    	}
    }
