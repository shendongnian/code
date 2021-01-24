    public static DateTime ConvertToUtc(DateTime timeOfInterest, string timezoneId)
    {
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
        if (tz.IsInvalidTime(timeOfInterest))
        {
            // Timezones with DST will be missing (usually) an hour one day a year, so some timeOfInterest
            // values are not valid
            throw new ArgumentOutOfRangeException($"{timeOfInterest} is not a valid time in {timezoneId} timezone");
        }
        return TimeZoneInfo.ConvertTimeToUtc(timeOfInterest, tz);
    }
