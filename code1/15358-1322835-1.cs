	private int CountDays(DateTime start, DateTime end, DayOfWeek selectedDay)
	{
		if (start.Date > end.Date)
		{
			return 0;
		}
		int totalDays = (int)end.Date.Subtract(start.Date).TotalDays;
		DayOfWeek startDay = start.DayOfWeek;
		DayOfWeek endDay = end.DayOfWeek;
		///look if endDay appears before or after the selectedDay when we start from startDay.
		int startToEnd = (int)endDay - (int)startDay;
		if (startToEnd < 0)
		{
			startToEnd += 7;
		}
		int startToSelected = (int)selectedDay - (int)startDay;
		if (startToSelected < 0)
		{
			startToSelected += 7;
		}
		bool isSelectedBetweenStartAndEnd = startToEnd >= startToSelected;
		if (isSelectedBetweenStartAndEnd)
		{
			return totalDays / 7 + 1;
		}
		else
		{
			return totalDays / 7;
		}
	}
