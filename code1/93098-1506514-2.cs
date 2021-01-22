    public static class DateExtensions
    {
        public static DateTime Next(this DateTime from, DayOfWeek dayOfWeek)
        {
            int start = (int)from.DayOfWeek;
            int wanted = (int)dayOfWeek;
            if (wanted < start)
                wanted += 7;
            return from.AddDays(wanted - start);
        }
        public static DateTime Previous(this DateTime from, DayOfWeek dayOfWeek)
        {
            int end = (int)from.DayOfWeek;
            int wanted = (int)dayOfWeek;
            if (wanted > end)
                end += 7;
            return from.AddDays(wanted - end);
        }
    }
