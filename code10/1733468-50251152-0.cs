    public static class DateTimeExtensions
	{
		public static bool EqualsUpToSeconds(this DateTime dt1, DateTime dt2)
		{
			dt1 = new DateTime(dt1.Year, dt1.Month, dt1.Day, dt1.Hour, dt1.Minute, dt1.Second);
			dt2 = new DateTime(dt2.Year, dt2.Month, dt2.Day, dt2.Hour, dt2.Minute, dt2.Second);
			return dt1.Equals(dt2);
		}
	}
