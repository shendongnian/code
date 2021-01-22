    public static class SystemTime
    {
        public static Func<DateTime> DateProvider = () => DateTime.Now;
    
        public static DateTime Now { get { return DateProvider(); } }
    }
