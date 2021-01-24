    public static class MyTimeZone
    {
        public static DateTime Now
        {
            get
            {
                return DateTime.UtcNow.AddHours(3);
            }
        }
    }
