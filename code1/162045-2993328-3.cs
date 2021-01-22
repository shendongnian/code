	public int StartMinuteInWeek()
	{
		return Day * 24 * 60 + StartTime.Hour * 60 + StartTime.Minute;
	}
	public int EndMinuteInWeek()
	{
		return StartMinuteInWeek() + Length;
	}
