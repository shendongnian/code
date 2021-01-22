    public DateTime TimeInOriginalZone { get { return TimeZoneInfo.ConvertTime(utcDateTime, timeZone); } }
    public DateTime TimeInLocalZone    { get { return TimeZoneInfo.ConvertTime(utcDateTime, TimeZoneInfo.Local); } }
    public DateTime TimeInSpecificZone(TimeZoneInfo tz)
    {
        return TimeZoneInfo.ConvertTime(utcDateTime, tz);
    }
