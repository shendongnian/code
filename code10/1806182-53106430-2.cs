    public static System.DateTime FromSpecificTimeZoneToUTC(TimeZoneInfo fromZone, System.DateTime specificTimeZoneDateTime)
    {
        System.DateTime temp = System.DateTime.SpecifyKind(specificTimeZoneDateTime, DateTimeKind.Unspecified);
        return TimeZoneInfo.ConvertTimeToUtc(temp, fromZone);
    }
           
    public static System.DateTime FromUTCToSpecificTimeZone(TimeZoneInfo toZone, System.DateTime UTCTimeZoneDateTime)
    {           
        return TimeZoneInfo.ConvertTimeFromUtc(UTCTimeZoneDateTime, toZone);
    }
