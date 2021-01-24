    public static DateTime FromSpecificTimeZoneToUTC(TimeZoneInfo fromZone, DateTime specificTimeZoneDateTime)
    {
        DateTime temp = DateTime.SpecifyKind(specificTimeZoneDateTime, DateTimeKind.Unspecified);
        return TimeZoneInfo.ConvertTimeToUtc(temp, fromZone);
    }
           
    public static DateTime FromUTCToSpecificTimeZone(TimeZoneInfo toZone, System.DateTime UTCTimeZoneDateTime)
    {           
        return TimeZoneInfo.ConvertTimeFromUtc(UTCTimeZoneDateTime, toZone);
    }
