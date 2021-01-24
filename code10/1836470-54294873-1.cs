    static IEnumerable<(DateTime start, DateTime end)> GetTimes(DateTime startTime, DateTime endTime, DayOfWeek startDay, int countWeeks)
	{
		if(endTime < startTime) throw new ArgumentException("TODO");
		TimeSpan diff = endTime - startTime;
		int daysUntilWeekDay = ((int) startDay - (int) startTime.DayOfWeek + 7) % 7;
		DateTime beginningDate = startTime.AddDays(daysUntilWeekDay);
		for (int i = 0; i <= countWeeks; i++)
		{
			DateTime date = beginningDate.AddDays(7 * i);
			yield return (start: date, end:date.Add(diff));
		}
	}
