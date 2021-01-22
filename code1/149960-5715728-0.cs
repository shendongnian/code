    public static class DateTimeExtensions
    {
        public static DateTime GetLastFridayInMonth(this DateTime date)
        {
            var firstDayOfNextMonth = new DateTime(date.Year, date.Month, 1).AddMonths(1);
            int vector = (((int)firstDayOfNextMonth.DayOfWeek + 1) % 7) + 1;
            return firstDayOfNextMonth.AddDays(-vector);
        }
    }
