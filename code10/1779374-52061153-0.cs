    public static class IEnumerableExtensions
    	{
    		public static IEnumerable<TSource> DistinctBy<TSource,TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
    		{
    			var keys = new HashSet<TKey>();
    			foreach (TSource item in source)
    			{
    				if (keys.Add(selector(item)))
    					yield return item;
    			}
    		}
    	}
