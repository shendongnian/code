    public static class DateTimeExtensions {
        public static DateTime Ago(this DateTime dateTime, TimeSpan delta) {
            return dateTime - delta;
        }
    }
