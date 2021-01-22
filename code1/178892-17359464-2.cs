    public static bool TryParse(this object value, out int? parsed)
    {
    	parsed = null;
    	try
    	{
    		if (value == null)
    			return true;
    
    		int parsedValue;
    		parsed = int.TryParse(value.ToString(), out parsedValue) ? (int?)parsedValue : null;
    		return true;
    	}
    	catch (Exception)
    	{
    		return false;
    	}
    }
