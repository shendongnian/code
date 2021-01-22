    public static class IEnumerableSortExtension
    {
    	public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
    			this IEnumerable<TSource> source,
    			Func<TSource, TKey> keySelector,
    			SortOrder order)
    	{
    		if (order == SortOrder.Ascending)
    			return this.OrderBy(keySelector);
    		else if (order == SortOrder.Descending)
    			return this.OrderByDescending(keySelector);
    		throw new InvalidOperationException(); // do something better than this
    	}
    }
