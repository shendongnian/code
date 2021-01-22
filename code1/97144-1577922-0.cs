	static class IEnumerableExtensions
	{
		public static IEnumerable<T> AsEnumerable<T>(this T item)
		{
			yield return item;
		}
	}
