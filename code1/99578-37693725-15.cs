    public static class DateTimeExtensions
    {
        // Transformed for SQL which numbers Mon=0 and Sun=6
        // 0123444401233334012222340111123400012345001234550
    
        static readonly int[,] _diffOffset = 
        {
          // Su M  Tu W  Th F  Sa
            {0, 1, 2, 3, 4, 5, 5}, // Su
            {4, 0, 1, 2, 3, 4, 4}, // M 
            {3, 4, 0, 1, 2, 3, 3}, // Tu
            {2, 3, 4, 0, 1, 2, 2}, // W 
            {1, 2, 3, 4, 0, 1, 1}, // Th
            {0, 1, 2, 3, 4, 0, 0}, // F 
            {0, 1, 2, 3, 4, 5, 0}, // Sa
        };
    
        private static readonly int[,] _addOffset = 
        {
          // 0  1  2  3  4
            {0, 1, 2, 3, 4}, // Su  0
            {0, 1, 2, 3, 4}, // M   1
            {0, 1, 2, 3, 6}, // Tu  2
            {0, 1, 4, 5, 6}, // W   3
            {0, 1, 4, 5, 6}, // Th  4
            {0, 3, 4, 5, 6}, // F   5
            {0, 2, 3, 4, 5}, // Sa  6
        };
    
        public static DateTime AddWeekdays(this DateTime date, int weekdays)
        {
            int extraDays = weekdays % 5;
            int addDays = weekdays >= 0
                ? (weekdays / 5) * 7 + _addOffset[(int)date.DayOfWeek, extraDays]
                : (weekdays / 5) * 7 - _addOffset[6 - (int)date.DayOfWeek, -extraDays];
            return date.AddDays(addDays);
        }
    
        public static int GetWeekdaysDiff(this DateTime dtStart, DateTime dtEnd)
        {
            int daysDiff = (int)(dtEnd - dtStart).TotalDays;
            return daysDiff >= 0
                ? 5 * (daysDiff / 7) + _diffOffset[(int) dtStart.DayOfWeek, (int) dtEnd.DayOfWeek]
                : 5 * (daysDiff / 7) - _diffOffset[6 - (int) dtStart.DayOfWeek, 6 - (int) dtEnd.DayOfWeek];
        }
    }
