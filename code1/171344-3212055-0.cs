    static class ExtensionMethods
    {
        private static readonly DateTime UnixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0);;
        public static bool IsYesterday(this int unixTime)
        {
            DateTime convertedTime = UnixStart.AddSeconds(unixTime);
            return convertedTime.Date == DateTime.Now.AddDays(-1).Date;
        }
        public static bool IsYesterday(this DateTime date)
        {
            return date.Date == DateTime.Now.AddDays(-1).Date;
        }
        public static bool IsYesterday(this DateTime date)
        {
            return date.Date == DateTime.Now.AddDays(-1).Date;
        }
    }
