    namespace System.Linq
	{
		public static class CustomLinqExtensions
		{
			public static SortedSet<TSource> ToSortedSet<TSource>(this IEnumerable<TSource> source)
			{
				if (source == null) throw Error.ArgumentNull("source");
				return new SortedSet<TSource>(source);
			}
		}
	}
