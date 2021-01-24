    using System;
    using NodaTime;
    
    class Test
    {
        static void Main()
        {
            var truncator = CreateTruncator(10);
            var start = new LocalDateTime(2018, 3, 21, 7, 32, 15);
            var truncated = start.With(truncator);
            Console.WriteLine(truncated); // 2018-03-21T07:30:00
        }
        
        static Func<LocalTime, LocalTime> CreateTruncator(int minuteGranularity) =>
            input => new LocalTime(
                input.Hour,
                input.Minute / minuteGranularity * minuteGranularity);
    }
