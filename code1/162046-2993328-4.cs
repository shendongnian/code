	public bool IsInsideInterval(int minuteInWeek)
	{
		return minuteInWeek >= StartMinuteInWeek() &&
			minuteInWeek <= EndMinuteInWeek();
	}
