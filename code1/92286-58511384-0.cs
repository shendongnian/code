        public static class DateTimeExtensions
    {
        public static DateTime StartOfQuarter(this DateTime _date)
        {
            var quarter = decimal.ToInt16(Math.Ceiling(_date.Month / 3.0m));
            return new DateTime(_date.Year, quarter, 1);
        }
    }
