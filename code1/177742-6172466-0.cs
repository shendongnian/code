        public static DateTime ToSafeUniversalTime(this DateTime date) {
            if(date != DateTime.MinValue && date != DateTime.MaxValue) {
                switch(date.Kind) {
                case DateTimeKind.Unspecified:
                    date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);
                    break;
                case DateTimeKind.Local:
                    date = date.ToUniversalTime();
                    break;
                }
            }
            return date;
        }
