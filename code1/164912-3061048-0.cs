    public static class DateTimeExtensions
    {
        public static DateTime AddMonthsCustom(this DateTime source, int months)
        {
            DateTime result = source.AddMonths(months);
            if (source.Day != DateTime.DaysInMonth(source.Year, source.Month))
                return result;
            return new DateTime(result.Year, result.Month,
                                DateTime.DaysInMonth(result.Year, result.Month),
                                result.Hour, result.Minute, result.Second,
                                result.Millisecond, result.Kind);
        }
    }
