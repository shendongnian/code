    public static class DatetimeExtensionMethod
    {
        public static TimeSpan LocalTimeSpanToUTC(this TimeSpan ts)
        {
            DateTime dt = DateTime.Now.Date.Add(ts);
            DateTime dtUtc = dt.ToUniversalTime();
            TimeSpan tsUtc = dtUtc.TimeOfDay;
            return tsUtc;
        }
        public static TimeSpan UTCTimeSpanToLocal(this TimeSpan tsUtc)
        {
            DateTime dtUtc = DateTime.UtcNow.Date.Add(tsUtc);
            DateTime dt = dtUtc.ToLocalTime();
            TimeSpan ts = dt.TimeOfDay;
            return ts;
        }
    }
