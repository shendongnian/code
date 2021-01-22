    public static class DaysOfWeekEvaluator
    {
        public static bool IsWeekends(DaysOfWeek days)
        {
            return (days & DaysOfWeek.Weekend) == DaysOfWeek.Weekend;
        }
        public static bool IsAllWeekdays(DaysOfWeek days)
        {
            return (days & DaysOfWeek.Weekdays) == DaysOfWeek.Weekdays;
        }
        public static bool HasWeekdays(DaysOfWeek days)
        {
            return ((int) (days & DaysOfWeek.Weekdays)) > 0;
        }
        public static bool HasWeekendDays(DaysOfWeek days)
        {
            return ((int) (days & DaysOfWeek.Weekend)) > 0;
        }
    }
