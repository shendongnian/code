	public static class EnumerableExtensions
	{
		public static IEnumerable<T> Between<T>(IEnumerable<T> items, Func<T, DateTime> selector, DateTime start, DateTime end)
		{
			return items.Where(x => selector(x).IsBetween(start, end));
		}
	}
