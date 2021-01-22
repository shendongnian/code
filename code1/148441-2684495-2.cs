    public static class DateTimeExtensions
    {
        public static IEnumerable<DateTime> Forwards(this DateTime dateTime)
        {
            return dateTime.Forwards(TimeSpan.FromDays(1));
        }
        public static IEnumerable<DateTime> Forwards(this DateTime dateTime, TimeSpan span)
        {
            while (true)
            {
                yield return dateTime += span;
            }
        }
        public static IEnumerable<DateTime> Backwards(this DateTime dateTime)
        {
            return dateTime.Backwards(TimeSpan.FromDays(1));
        }
        public static IEnumerable<DateTime> Backwards(this DateTime dateTime, TimeSpan span)
        {
            return dateTime.Forwards(-span);
        }
        public static bool IsWorkingDay(this DateTime dateTime)
        {
            return dateTime.IsWorkingDay(Thread.CurrentThread.CurrentUICulture);
        }
        public static bool IsWorkingDay(this DateTime dateTime, CultureInfo culture)
        {
            return !dateTime.IsWeekend(culture)
                && !dateTime.IsHoliday(culture);
        }
        public static bool IsWeekend(this DateTime dateTime)
        {
            return dateTime.IsWeekend(Thread.CurrentThread.CurrentUICulture);
        }
        public static bool IsWeekend(this DateTime dateTime, CultureInfo culture)
        {
            // TOOD: Make culturally aware
            return dateTime.DayOfWeek == DayOfWeek.Saturday
                || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }
        public static bool IsHoliday(this DateTime dateTime)
        {
            return dateTime.IsHoliday(Thread.CurrentThread.CurrentUICulture);
        }
        public static bool IsHoliday(this DateTime dateTime, CultureInfo culture)
        {
            throw new NotImplementedException("TODO: Get some culture aware holiday data");
        }
    }
