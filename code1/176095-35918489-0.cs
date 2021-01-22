	public string GetTimeInEasternStandardTime(DateTime time)
	{
		TimeZoneInfo easternStandardTime = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
		DateTimeOffset timeInEST = TimeZoneInfo.ConvertTime(time, easternStandardTime);
		return timeInEST.ToString("yyyy-MM-dd hh:mm:ss\"GMT\"zzz");
	}
