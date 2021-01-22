        public static bool IsNthDayofMonth(this DateTime date, DayOfWeek weekday, int N)
        {
            if (N > 0)
            {
                var first = new DateTime(date.Year, date.Month, 1);
                return (date.Day - first.Day)/ 7 == N - 1 && date.DayOfWeek == weekday;
            }
            else
            {
                var last = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
                return (last.Day - date.Day) / 7 == (Math.Abs(N) - 1) && date.DayOfWeek == weekday;
            }
      
