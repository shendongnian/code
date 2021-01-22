    // In a User class that has a string timeZoneId field (for example)
    public DateTime GetLocalDateTime(DateTime originalDate) {
        DateTime utcDate      = TimeZoneInfo.Local.ConvertToUtc(originalDate);
        TimeZone userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(this.timeZoneId);
        return   TimeZone.ConvertTime(utcDate, userTimeZone);
    }
