		public static DateTime EndOfWeek(this DateTime dt)
		{
			int diff = 7 - (int)dt.DayOfWeek;
			diff = diff == 7 ? 0 : diff;
			DateTime eow = dt.AddDays(diff).Date;
			return new DateTime(eow.Year, eow.Month, eow.Day, 23, 59, 59, 9999) { };
		}
