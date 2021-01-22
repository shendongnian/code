    class Program
    {
        static void Main(string[] args)
        {
            DateTime dUtc = new DateTime(2016, 6, 1, 3, 17, 0, 0, DateTimeKind.Utc);
            DateTime dUnspecified = new DateTime(2016, 6, 1, 3, 17, 0, 0, DateTimeKind.Unspecified);
            //Sample of an unintended mangle:
            //Prints "2016-06-01 10:17:00Z"
            Console.WriteLine(dUnspecified.ToUniversalTime().ToString("u"));
            //Prints "2016 - 06 - 01 03:17:00Z"
            Console.WriteLine(dUtc.SafeUniversal().ToString("u"));
            //Prints "2016 - 06 - 01 03:17:00Z"
            Console.WriteLine(dUnspecified.SafeUniversal().ToString("u"));
        }
    }
    public static class ConvertExtensions
    {
        public static DateTime SafeUniversal(this DateTime inTime)
        {
            return (DateTimeKind.Unspecified == inTime.Kind)
                ? new DateTime(inTime.Ticks, DateTimeKind.Utc)
                : inTime.ToUniversalTime();
        }
    }
