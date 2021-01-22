    public static DateTime JavaTimeStampToDateTime(double javaTimeStamp)
    {
    	// Java timestamp is millisecods past epoch
    	System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
    	dtDateTime = dtDateTime.AddSeconds(Math.Round(javaTimeStamp / 1000)).ToLocalTime();
    	return dtDateTime;
    }
