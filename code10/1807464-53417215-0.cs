	public static IEnumerable<TResult> ZipLoop<TFirst, TSecond, TResult>(
		this IEnumerable<TFirst> first,
		IEnumerable<TSecond> second,
		Func<TFirst, TSecond, TResult> resultSelector)
	{
		if (first is null) throw new ArgumentNullException(nameof(first));
		if (second is null) throw new ArgumentNullException(nameof(second));
		if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));
		var (firstCycle, secondCycle) = (false, false);
		var e1 = first.GetEnumerator();
		var e2 = second.GetEnumerator();
		try
		{
			while (true)
			{
				if (!TryMoveNextOrLoop(first, ref e1, ref firstCycle)) yield break;
				if (!TryMoveNextOrLoop(second, ref e2, ref secondCycle)) yield break;
				if (firstCycle && secondCycle) yield break;
				yield return resultSelector(e1.Current, e2.Current);
			}
		}
		finally
		{
			e1?.Dispose();
			e2?.Dispose();
		}
	}
	private static bool TryMoveNextOrLoop<T>(IEnumerable<T> source, ref IEnumerator<T> enumerator, ref bool cycle)
	{
		if (!enumerator.MoveNext())
		{
			cycle = true;
			enumerator.Dispose();
			enumerator = source.GetEnumerator();
			return enumerator.MoveNext();			
		}
		return true;
	}
