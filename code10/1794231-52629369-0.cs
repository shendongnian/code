    static DateTime GetDate(string Column0) {
    	DateTime dt;
    	if (!DateTime.TryParseExact(Column0, "MM/dd/MM hh:mm:18 PM",
    			   CultureInfo.InvariantCulture,
    			   DateTimeStyles.None, out dt))
    	{
    		dt = new DateTime(1990, 1, 1);
    	}
    
    	return dt;
    }
