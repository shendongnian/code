	public static IEnumerable<TResult> Merge<TFirst,TSecond,TResult>(this IEnumerable<TFirst> first,
				IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> operation) {
		using (var iter1 = first.GetEnumerator()) {
			using (var iter2 = second.GetEnumerator()) {
				while (iter1.MoveNext()) {
					if (iter2.MoveNext()) {
						yield return operation(iter1.Current, iter2.Current);
					} else {
						yield return operation(iter1.Current, default(TSecond));
					}
				}
				while (iter2.MoveNext()) {
					yield return operation(default(TFirst),  iter2.Current);
				}
			}
		}
	}
