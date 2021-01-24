     static class DateExtensions
        {
            public static IEnumerable<DateTime> GetRange(this DateTime source, int days)
            {
                for (var current = 0; current < days; ++current)
                {
                    yield return source.AddDays(current);
                };
            }
    
            public static DateTime NextDayOfWeek(this DateTime start, DayOfWeek dayOfWeek)
            {
                while (start.DayOfWeek != dayOfWeek)
                    start = start.AddDays(-1);
    
                return start;
            }
        }
