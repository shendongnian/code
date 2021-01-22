	public static class Extensions
	{
		public static bool Contains(this string source, string value, StringComparison comp)
		{
			return source.IndexOf(value, comp) > -1;
		}
		public static bool ContainsAny(this string source, IEnumerable<string> values, StringComparison comp = StringComparison.CurrentCulture)
		{
			return values.Any(value => source.Contains(value, comp));
		}
		public static bool ContainsAll(this string source, IEnumerable<string> values, StringComparison comp = StringComparison.CurrentCulture)
		{
			return values.All(value => source.Contains(value, comp));
		}
	}
