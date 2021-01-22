    public static class DateTimeExtension
    {
        public static DateTime GetFirstDayOfWeek(this DateTime date)
        {
            var firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
           
            while (date.DayOfWeek != firstDayOfWeek)
            {
                date = date.AddDays(-1);
            }
            return date;
        }
    }
