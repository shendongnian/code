        public static DateTime GetDateTime(this long unixDateTime)
        {
            return Epoch.AddSeconds(unixDateTime);
        }
        public static DateTime GetDateTimeUltra(this long unixUltraDateTime)
        {
            return Epoch.AddMilliseconds(unixUltraDateTime);
        }
