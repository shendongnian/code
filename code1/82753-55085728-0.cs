    public DateTime getCurrentDateTimeWithTimeZone(string strTimeZone)
        {
            var localTimezone = TimeZoneInfo.Local;
            var userTimezone = TimeZoneInfo.FindSystemTimeZoneById(strTimeZone);
            var todayDate = DateTime.Now;
            var todayLocal = new DateTimeOffset(todayDate,
                                                localTimezone.GetUtcOffset(todayDate));
            var todayUserOffset = TimeZoneInfo.ConvertTime(todayLocal, userTimezone);
            return todayUserOffset.DateTime;
        }
