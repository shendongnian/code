    public static class Integration
    {
        private static readonly TimeZoneInfo NewZealand = TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time");
    
        public static void ImportRosters(
            Action<string> log,
            string connectionString,
            int siteID,
            DateTime nowUtc,
            int actualDays,
            int rosterDays
            )
        {
            var localDateTime = TimeZoneInfo.ConvertTimeFromUtc(nowUtc, NewZealand);
            log($"Roster Data import function executed at: {localDateTime}");
        }
    }
