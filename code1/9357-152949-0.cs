        static DateTime TrimDate(DateTime date, long roundTicks)
        {
            return new DateTime(date.Ticks - date.Ticks % roundTicks);
        }
        //sample usage:
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(TrimDate(DateTime.Now, TimeSpan.TicksPerDay));
            Console.WriteLine(TrimDate(DateTime.Now, TimeSpan.TicksPerHour));
            Console.WriteLine(TrimDate(DateTime.Now, TimeSpan.TicksPerMillisecond));
            Console.WriteLine(TrimDate(DateTime.Now, TimeSpan.TicksPerMinute));
            Console.WriteLine(TrimDate(DateTime.Now, TimeSpan.TicksPerSecond));
            Console.ReadLine();
        }
