        public static DateTime _ToDateTime(this long unixEpochTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var date = epoch.AddMilliseconds(unixEpochTime);
            if (date.Year > 1972)
                return date;
            return epoch.AddSeconds(unixEpochTime);
        }
