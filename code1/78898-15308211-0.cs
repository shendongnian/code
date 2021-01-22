    public DateTime IndianStandard(DateTime currentDate)
    {
        TimeZoneInfo mountain = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime utc = currentDate;
        return TimeZoneInfo.ConvertTimeFromUtc(utc, mountain);
    }
