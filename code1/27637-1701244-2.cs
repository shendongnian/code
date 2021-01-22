    public static bool IsNumeric(string anyString)
    {
    	if (anyString == null)
    	{
    	    anyString = "";
    	}
    
    	if (anyString.Length > 0)
    	{
    	    double dummyOut = new double();
    	    System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US", true);
    	    return Double.TryParse(anyString, System.Globalization.NumberStyles.Any, cultureInfo.NumberFormat, out dummyOut);
    	}
    	else
    	{
    	    return false;
    	}
    }
