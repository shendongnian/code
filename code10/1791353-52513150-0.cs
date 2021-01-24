    public static bool ContainsDuplicates<T>(IEnumerable<T> items, IEnumerable<T> itemsToExclude = null)
	{
		if (itemsToExclude == null) itemsToExclude = Enumerable.Empty<T>();
		return items.Except(itemsToExclude)
                    .GroupBy(n => n)
                    .Any(c => c.Count() > 1);
	}
