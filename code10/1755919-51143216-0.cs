	public static class MyEnumerableExtensions
	{
		public static void ForceExecute<T>(this IEnumerable<T> source)
		{
			foreach (T item in source);
		}
	}
