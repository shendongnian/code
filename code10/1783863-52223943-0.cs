	public static class LinqExtensions
	{
		public static IEnumerable<KeyValuePair<TKey,(T1,T2)>> Where<TKey,T1,T2>(
			this IEnumerable<KeyValuePair<TKey,(T1,T2)>> source ,
			Func<TKey,T1,T2, Boolean> predicate )
            => source.Where( predicate );
	}
