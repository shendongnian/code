	public static IEnumerable<int> AllIndexesOf<T>(this IEnumerable<T> seq, T itemToFind, EqualityComparer<T> comparer = null)
	{
		if (comparer == null)
			comparer = EqualityComparer<T>.Default;
		var indexes = new List<int>();
		int index = 0;
		foreach (T item in seq)
		{
			if (comparer.Equals(itemToFind, item))
				yield return index;
			index++;
		}
	}
