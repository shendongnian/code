        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.NextDay())
                yield return day;
        }
        public static IEnumerable<DateTime> EachMonth(DateTime from, DateTime thru)
        {
            for (var month = from.Date; month.Date <= thru.Date || month.Year == thru.Year && month.Month == thru.Month; month = month.NextMonth())
                yield return month;
        }
        public static IEnumerable<DateTime> EachYear(DateTime from, DateTime thru)
        {
            for (var year = from.Date; year.Date <= thru.Date || year.Year == thru.Year; year = year.NextYear())
                yield return year;
        }
        public static DateTime NextDay(this DateTime date)
        {
            return date.AddTicks(TimeSpan.TicksPerDay - date.TimeOfDay.Ticks);
        }
        public static DateTime NextMonth(this DateTime date)
        {
            return date.AddTicks(TimeSpan.TicksPerDay * DateTime.DaysInMonth(date.Year, date.Month) - (date.TimeOfDay.Ticks + TimeSpan.TicksPerDay * (date.Day - 1)));
        }
        public static DateTime NextYear(this DateTime date)
        {
            var yearTicks = (new DateTime(date.Year + 1, 1, 1) - new DateTime(date.Year, 1, 1)).Ticks;
            var ticks = (date - new DateTime(date.Year, 1, 1)).Ticks;
            return date.AddTicks(yearTicks - ticks);
        }
        public static IEnumerable<DateTime> EachDayTo(this DateTime dateFrom, DateTime dateTo)
        {
            return EachDay(dateFrom, dateTo);
        }
        public static IEnumerable<DateTime> EachMonthTo(this DateTime dateFrom, DateTime dateTo)
        {
            return EachMonth(dateFrom, dateTo);
        }
        public static IEnumerable<DateTime> EachYearTo(this DateTime dateFrom, DateTime dateTo)
        {
            return EachYear(dateFrom, dateTo);
        }
