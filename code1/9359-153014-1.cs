    static class Program
    {
        //using extension method:
        static DateTime Trim(this DateTime date, long roundTicks)
        {
            return new DateTime(date.Ticks - date.Ticks % roundTicks, date.Kind);
        }
        //sample usage:
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTime.Now.Trim(TimeSpan.TicksPerDay));
            Console.WriteLine(DateTime.Now.Trim(TimeSpan.TicksPerHour));
            Console.WriteLine(DateTime.Now.Trim(TimeSpan.TicksPerMillisecond));
            Console.WriteLine(DateTime.Now.Trim(TimeSpan.TicksPerMinute));
            Console.WriteLine(DateTime.Now.Trim(TimeSpan.TicksPerSecond));
            Console.ReadLine();
        }
    }
