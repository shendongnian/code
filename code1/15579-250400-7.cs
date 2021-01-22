    public static DateTime JavaTimeStampToDateTime( double javaTimeStamp )
    {
    	// Java timestamp is milliseconds past epoch
    	System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
    	dtDateTime = dtDateTime.AddMilliseconds( javaTimeStamp ).ToLocalTime();
    	return dtDateTime;
    }
