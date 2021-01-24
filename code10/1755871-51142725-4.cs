    public static class Extensions
    {
        // NOT set to UTC
        private static readonly DateTime UnixEpoch = new DateTime(2017, 6, 1, 8, 0, 0);
        public static DateTime ToDateTime(this Int64 _input)
        {
            return UnixEpoch.AddSeconds(_input);
        }
        public static long ToUTC(this DateTime _input)
        {
            // NOT converted to UTC. So... change variable names accordingly.
            var utcTime = _input;
            var totalSeconds = utcTime.Subtract(UnixEpoch).TotalSeconds;
            return Convert.ToInt64(totalSeconds);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Notice that the object is in local time and NOT UTC.
            var dateObj = new DateTime(2017, 6, 1, 9, 0, 0);
            long dateInLong = dateObj.ToUTC();
            Console.WriteLine(dateInLong);
            Console.WriteLine(dateInLong.ToDateTime());
            Console.ReadLine();
        }
    }
