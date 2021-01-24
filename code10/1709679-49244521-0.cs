    static class DayOfWeekExtensions {
        public static bool IsWeekEnd(DayOfWeek dow) {
            return dow == DayOfWeek.Saturday || dow == DayOfWeek.Sunday;
        }
    }
