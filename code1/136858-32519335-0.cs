    public static class SystemTime
        {
            private static Func<DateTime> UtcNowFunc = () => DateTime.UtcNow;
    
            public static void SetDateTime(DateTime dateTimeNow)
            {
                UtcNowFunc = () => dateTimeNow;
            }
    
            public static void ResetDateTime()
            {
                UtcNowFunc = () => DateTime.UtcNow;
            }
    
            public static DateTime UtcNow
            {
                get
                {
                    DateTime now = UtcNowFunc.Invoke();
                    return now;
                }
            }
        }
