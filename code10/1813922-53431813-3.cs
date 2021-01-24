    public static class ICollectionExtensions
    {
    	public static void Add<T>(this ICollection<T> collection, IEnumerable<T> items)
    	{
    		foreach (var item in items)
    		{
    			collection.Add(item);
    		}
    	}
    }
