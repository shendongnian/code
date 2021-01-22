    public static class TimeSpanExtensions {
        public static TimeSpan Days(this int value) {
            return new TimeSpan(value, 0, 0, 0);
        }
        public static TimeSpan Hours(this int value) {
            return new TimeSpan(0, value, 0, 0);
        }
        public static TimeSpan Minutes(this int value) {
            return new TimeSpan(0, 0, value, 0);
        }
        public static TimeSpan Seconds(this int value) {
            return new TimeSpan(0, 0, 0, value);
        }
        public static TimeSpan Milliseconds(this int value) {
            return new TimeSpan(0, 0, 0, 0, value);
        }
        public static DateTime Ago(this TimeSpan value) {
            return DateTime.Now - value;
        }
    }
