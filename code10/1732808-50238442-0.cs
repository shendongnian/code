    public static DateTimeOffset GetDateTimeOffset(DateTime sourceDateTime, string timeZoneId)
    {
        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        // here, is where you need to convert
        if (sourceDateTime.Kind != DateTimeKind.Unspecified)
            sourceDateTime = TimeZoneInfo.ConvertTime(sourceDateTime, timeZone);
        TimeSpan offset = timeZone.GetUtcOffset(sourceDateTime);
        return new DateTimeOffset(sourceDateTime, offset);
    }
