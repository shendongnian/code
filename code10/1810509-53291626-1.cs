    namespace System.Linq
	{
        public static class CustomLinqExtensions
        {
            public static SortedSet<TSource> ToSortedSet<TSource>(this IEnumerable<TSource> source)
            {
                if (source == null) throw new ArgumentNullException(nameof(source));
                return new SortedSet<TSource>(source);
            }
            public static SortedSet<TSource> ToSortedSet<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer)
            {
                if (source == null) throw new ArgumentNullException(nameof(source));
                return new SortedSet<TSource>(source, comparer);
            }
        }
	}
