    public static string FormatDateForQuery(DateTime dateToFormat, bool includeTime)
    {
    	if (includeTime)
    	{
    		return dateToFormat.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss+00:00");
    	}
    	else
    	{
    		return dateToFormat.ToUniversalTime().ToString("yyyy-MM-dd");
    	}
    }
