    public DateTime ConvertUtcDateTime(DateTime utcDateTime, string timeZoneId)
    {
        var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        var convertedDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, tz);
        return convertedDateTime;
    }
