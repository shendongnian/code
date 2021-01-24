    public static bool ContainsDuplicates<T>(this IEnumerable<T> items, IEnumerable<T> itemsToExclude = null)
	{
		if (itemsToExclude == null) itemsToExclude = Enumerable.Empty<T>();
		HashSet<T> set = new HashSet<T>();
		return !items.Except(itemsToExclude).All(set.Add);
	}
