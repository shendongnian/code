        public static DateTime ToDateTime(this long unixDateTime)
        {
            return Epoch.AddSeconds(unixDateTime);
        }
        public static DateTime ToDateTimeUltra(this long unixUltraDateTime)
        {
            return Epoch.AddMilliseconds(unixUltraDateTime);
        }
