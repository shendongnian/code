    public static bool IsSwedishMidsummerDay(DateTime dt)
	{
		return dt.DayOfWeek == DayOfWeek.Saturday 
            && dt.Month == 6 && dt.Day >= 20 && dt.Day <= 26);
	}
