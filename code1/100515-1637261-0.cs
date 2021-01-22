    // In a User class that has a double gmtOffset field (for example)
    public DateTime GetLocalDateTime(DateTime originalDate) {
        DateTime gmtDate = TimeZone.CurrentTimeZone.ToUniversalTime(originalDate);
        return gmtDate.AddHours(this.gmtOffset);
    }
    // Usage
    DateTime localDate = user.GetLocalDateTime(DateTime.Now);
