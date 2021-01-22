    // In a User class that has a double utcOffset field (for example)
    public DateTime GetLocalDateTime(DateTime originalDate) {
        DateTime utcDate = TimeZone.CurrentTimeZone.ToUniversalTime(originalDate);
        return utcDate.AddHours(this.utcOffset);
    }
    // Usage
    DateTime localDate = user.GetLocalDateTime(DateTime.Now);
