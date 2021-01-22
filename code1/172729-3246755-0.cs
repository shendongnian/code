           static ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();       
    public static DateTime ToUsersTime(this DateTime utcDate, int timeZoneId)
            {
                return TimeZoneInfo.ConvertTimeFromUtc(utcDate, timeZones[timeZoneId]);
            }
