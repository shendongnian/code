	public static DateTime SetPart(this DateTime dateTime, int? year, int? month, int? day, int? hour, int? minute, int? second)
	{
	    return new DateTime(
	        year ?? dateTime.Year,
	        month ?? dateTime.Month,
	        day ?? dateTime.Day,
	        hour ?? dateTime.Hour,
	        minute ?? dateTime.Minute,
	        second ?? dateTime.Second
	    );
	}
	public static DateTime SetYear(this DateTime dateTime, int year)
	{
	    return dateTime.SetPart(year, null, null, null, null, null);
	}
	public static DateTime SetMonth(this DateTime dateTime, int month)
	{
	    return dateTime.SetPart(null, month, null, null, null, null);
	}
	public static DateTime SetDay(this DateTime dateTime, int day)
	{
	    return dateTime.SetPart(null, null, day, null, null, null);
	}
	public static DateTime SetHour(this DateTime dateTime, int hour)
	{
	    return dateTime.SetPart(null, null, null, hour, null, null);
	}
	public static DateTime SetMinute(this DateTime dateTime, int minute)
	{
	    return dateTime.SetPart(null, null, null, null, minute, null);
	}
	public static DateTime SetSecond(this DateTime dateTime, int second)
	{
	    return dateTime.SetPart(null, null, null, null, null, second);
	}
