    public static class DateTimeExtensions
    {
        public static int WeekNumber(this DateTime date)
        {
            var cal = new GregorianCalendar();
            var week = cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            return week;
        }
    }
