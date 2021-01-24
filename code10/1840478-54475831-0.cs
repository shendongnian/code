    namespace MyWpfApplication
    {
        public static class MyDateTime
        {
            public static DateTime TenDaysAgo => System.DateTime.Now.AddDays(-10);
        }
    }
