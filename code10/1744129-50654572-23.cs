	public static class DateTimeExtensions
	{
		public static bool IsBetween(this DateTime thisDateTime, DateTime start, DateTime end)
		{
			return thisDateTime >= start && thisDateTime <= end;
		}
	}
