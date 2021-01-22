    // _timeZoneId is the String value found in the System Registry.
    // You can look up the list of TimeZones on your system using this:
    // ReadOnlyCollection<TimeZoneInfo> current = TimeZoneInfo.GetSystemTimeZones();
    // As long as your _timeZoneId string is in the registry 
    // the _now DateTime object will contain
    // the current time (adjusted for Daylight Savings Time) for that Time Zone.
    string _timeZoneId = "Pacific Standard Time";
    DateTime startTime = DateTime.UtcNow;
    TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById(_timeZoneId);
    _now = TimeZoneInfo.ConvertTime(startTime, TimeZoneInfo.Utc, tst);
