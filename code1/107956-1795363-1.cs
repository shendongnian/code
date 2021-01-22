    public static class DateTimeExtensions
    {
        public static DateTime GetLastWeekdayOfMonth(this DateTime date, DayOfWeek day)
        {
            DateTime lastDayOfMonth = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
            return lastDayOfMonth.AddDays((int)day - (int)lastDayOfMonth.DayOfWeek);
        }
    }
