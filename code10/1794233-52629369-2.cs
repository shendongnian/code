    static DateTime GetDate(string Column0) {
    	DateTime dt;
    	if (!DateTime.TryParseExact(Column0, "MM/dd/YYYY hh:mm:18 PM",
    			   CultureInfo.InvariantCulture,
    			   DateTimeStyles.None, out dt))
    	{
    		dt = DateTime.MinValue;
    	}
    
    	return dt;
    }
