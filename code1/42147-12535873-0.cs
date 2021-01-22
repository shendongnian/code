	public static DateTime GetFirstDayOfWeek(int year, int week, DayOfWeek firstDayOfWeek)
	{
		return GetWeek1Day1(year, firstDayOfWeek).AddDays(7 * (week - 1));
	}
	public static DateTime GetWeek1Day1(int year, DayOfWeek firstDayOfWeek)
	{
		DateTime date = new DateTime(year, 1, 1);
		// Move towards firstDayOfWeek
		date = date.AddDays(firstDayOfWeek - date.DayOfWeek);
		// Either 1 or 52 or 53
		int weekOfYear = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFullWeek, firstDayOfWeek);
		// Move forwards 1 week if week is 52 or 53
		date = date.AddDays(7 * System.Math.Sign(weekOfYear - 1));
		return date;
	}
