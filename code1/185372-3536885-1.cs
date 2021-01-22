    public static class Extensions
    {
        public static string To24HourTime(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm:ss");
        }
    }
