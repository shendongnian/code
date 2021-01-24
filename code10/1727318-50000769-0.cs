    public static Tuple<DateTime, DateTime> GetFirstAndLastWeekDate(DateTime dt, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
	{
		int diff = (7 + (dt.DayOfWeek - firstDayOfWeek)) % 7;
		DateTime firstDay = dt.AddDays(-1 * diff).Date;
		DateTime lastDay = firstDay.AddDays(6);
		if (dt.Month != firstDay.Month)
		{
			firstDay = new DateTime(dt.Year, dt.Month, 1);
		}
		return Tuple.Create(firstDay, lastDay);
	}
