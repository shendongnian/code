	/// <summary>
	/// Takes two sequences and returns a sequence of corresponding pairs. 
	/// If one sequence is short, excess elements of the longer sequence are discarded.
	/// </summary>
	/// <typeparam name="T1">The type of the 1.</typeparam>
	/// <typeparam name="T2">The type of the 2.</typeparam>
	/// <param name="sequence1">The first sequence.</param>
	/// <param name="sequence2">The second sequence.</param>
	/// <returns></returns>
	public static IEnumerable<Tuple<T1, T2>> Zip<T1, T2>(
		this IEnumerable<T1> sequence1, IEnumerable<T2> sequence2) {
		using (
			IEnumerator<T1> enumerator1 = sequence1.GetEnumerator())
		using (
			IEnumerator<T2> enumerator2 = sequence2.GetEnumerator()) {
			while (enumerator1.MoveNext() && enumerator2.MoveNext()) {
				yield return
					Pair.New(enumerator1.Current, enumerator2.Current);
			}
		}
		//
		//zip :: [a] -> [b] -> [(a,b)]
		//zip (a:as) (b:bs) = (a,b) : zip as bs
		//zip _      _      = []
	}
