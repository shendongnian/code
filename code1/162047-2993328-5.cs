	foreach (TimeInterval rec in overlaps)
	{
		if (rec.StartMinuteInWeek() < newInterval.StartMinuteInWeek())
		{
			newInterval.Day = rec.Day;
			newInterval.StartTime = rec.StartTime;
		}
		if (rec.EndMinuteInWeek() > newInterval.EndMinuteInWeek())
		{
			// You have to calc the Length being careful to not count twice the minutes that overlaps.
			newInterval.Length = newInterval.Length + rec.Length - (newInterval.EndMinuteInWeek() - rec.StartMinuteInWeek());
		}
	}
