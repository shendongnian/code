	public static IEnumerable<int> AllIndexesOf<T>(this IEnumerable<T> seq, T itemToFind, EqualityComparer<T> comparer = null)
	{
		if (comparer == null)
			comparer = EqualityComparer<T>.Default;
		int index = 0;
		foreach (T item in seq)
		{
			if (comparer.Equals(itemToFind, item))
				yield return index;
			index++;
		}
	}
