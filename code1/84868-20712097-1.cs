    void Main()
    {
    	var startDate = DateTime.Today;
    	var StartDateUtc = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.SpecifyKind(startDate.Date, DateTimeKind.Unspecified), "Eastern Standard Time", "UTC");
    	startDate.Dump();
    	StartDateUtc.Dump();
    }
