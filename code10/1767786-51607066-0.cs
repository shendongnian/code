    // No need to do this more than once
    private static readonly TimeZoneInfo centralEuropeZone = 
        TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time")
    private static DateTime GetUtcResetTime()
    {
        // Using UtcNow to make it clear that the system time zone is irrelevant
        var centralEuropeNow = TimeZoneInfo.ConvertTime(DateTime.UtcNow, centralEuropeZone);
        var centralEuropeResetTime = centralEuropeNow.Date + new TimeSpan(9, 10, 0);
        if (centralEuropeResetTime <= centralEuropeNow)
        {
            centralEuropeResetTime = centralEuropeResetTime.AddDays(1);
        }
        return TimeZoneInfo.ConvertTimeToUtc(centralEuropeResetTime, centralEuropeZone);
    }
