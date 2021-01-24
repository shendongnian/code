    // Converts timestamp to DateTime
    public class DateTimeConverter : ITypeConverter<long?, DateTime?>
	{
		private readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		public DateTime? Convert(long? source, DateTime? destination, ResolutionContext context)
		{
			if (!source.HasValue) return null;
			return _epoch.AddSeconds(source.Value);
		}
	}
    // Converts DateTime to Timestamp
    public class TimeStampConverter : ITypeConverter<DateTime?, long?>
    {
        private readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public long? Convert(DateTime? source, long? destination, ResolutionContext context)
        {
            if (source == null) return null;
            var result = (long)(source - _epoch).Value.TotalSeconds;
            return result;
        }
    }
