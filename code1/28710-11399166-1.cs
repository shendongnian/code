    public static class Extensions
    {
    	public static IDictionary<TKey,int> CountBy<TSource,TKey>(this IEnumerable<TSource> source, Func<TSource,TKey> keySelector)
    	{
    		if (source==null)
    		{
    			throw new ArgumentNullException("source");
    		}
    		var countsByKey = new Dictionary<TKey,int>();
    		foreach(var x in source)
    		{
    			var key = keySelector(x);
    			if (! countsByKey.ContainsKey(key))
    			{
    				countsByKey[key] = 0;
    			}
    			countsByKey[key] += 1;
    			
    		}
    		return countsByKey;
    	}
    }
