	public static class DataReaderExtensions
	{
		public static DateTime GetUtcDateTime(this IDataReader reader, int ordinal)
		{
			var readDateTime = reader.GetDateTime(ordinal);
			return DateTime.SpecifyKind(readDateTime, DateTimeKind.Utc);
		}
	}
