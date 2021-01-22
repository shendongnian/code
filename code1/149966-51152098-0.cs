    public static DateTime GetLastSpecificDayOfTheMonth(this DateTime date, DayOfWeek dayofweek)
        {
            var lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            while (lastDayOfMonth.DayOfWeek != dayofweek)
                lastDayOfMonth = lastDayOfMonth.AddDays(-1);
            return lastDayOfMonth;
        }
