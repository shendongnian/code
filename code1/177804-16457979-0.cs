        public static DateTime ToEndOfDay(this DateTime time)
        {
			var endOfDaySpan = TimeSpan.FromDays(1).Subtract(TimeSpan.FromMilliseconds(1));
            return time.Date.Add(endOfDaySpan);
        }
