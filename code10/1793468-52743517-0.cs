	internal static class UntypedLinq
	{
		public static bool Any(this IEnumerable source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			IEnumerator ator = source.GetEnumerator();
			// Unfortunately unlike IEnumerator<T>, IEnumerator does not implement
			// IDisposable. (A design flaw fixed when IEnumerator<T> was added).
			// We need to test whether disposal is required or not.
			if (ator is IDisposable disp)
			{
				using(disp)
				{
					return ator.MoveNext();
				}
			}
			
			return ator.MoveNext();
		}
	
		// Not completely necessary. Causes any typed enumerables to be handled by the existing Any
		// in Linq via a short method that will be inlined.
		public static bool Any<T>(this IEnumerable<T> source) => Enumerable.Any(source);
	}
