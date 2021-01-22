    public static bool IsNumeric(this String str)
    {
    	try
    	{
    		Double.Parse(str.ToString());
    		return true;
    	}
    	catch {
    	}
    	return false;
    }
