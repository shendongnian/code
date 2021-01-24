    public static DateTime ConvertTimeToUtc(DateTime dt, TimeZoneInfo tz, bool useDST)
    {
        if (useDST)
        {
            // the normal way (converts using the time in effect - standard or daylight)
            return TimeZoneInfo.ConvertTimeToUtc(dt, tz);
        }
        // the way to convert with just the standard time (even when DST is in effect)
        var dto = new DateTimeOffset(dt, tz.BaseUtcOffset);
        return dto.UtcDateTime;
    }
