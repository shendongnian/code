	public static IEnumerable<V> Zip<T, U, V>(
		this IEnumerable<T> one,
		IEnumerable<U> two,
		Func<T, U, V> f)
	{
		using (var oneIter = one.GetEnumerator()) {
			using (var twoIter = two.GetEnumerator()) {
				while (oneIter.MoveNext()) {
					twoIter.MoveNext();
					yield return f(oneIter.Current,
						twoIter.MoveNext() ?
							twoIter.Current :
							default(U));
				}
				while (twoIter.MoveNext()) {
					yield return f(oneIter.Current, twoIter.Current);
				}
			}
		}
	}
