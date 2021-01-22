		public static TimeSpan Round(this TimeSpan time, TimeSpan roundingInterval, MidpointRounding roundingType) {
			return new TimeSpan(
				Convert.ToInt64(Math.Round(
					time.Ticks / (decimal)roundingInterval.Ticks,
					roundingType
				)) * roundingInterval.Ticks
			);
		}
		public static TimeSpan Round(this TimeSpan time, TimeSpan roundingInterval) {
			return Round(time, roundingInterval, MidpointRounding.ToEven);
		}
		public static DateTime Round(this DateTime datetime, TimeSpan roundingInterval) {
			return new DateTime((datetime - DateTime.MinValue).Round(roundingInterval).Ticks);
		}
