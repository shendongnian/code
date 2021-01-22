    public static class ListExtensions
    {
       public static IEnumerable<TSource> ByIndexes<TSource>(this IList<TSource> source, params int[] indexes)
       {   		
    		if (indexes == null || indexes.Length == 0)
    		{
    			foreach (var item in source)
    			{
    				yield return item;
    			}
    		}
    		else
    		{
    			foreach (var i in indexes)
    			{
    				if (i >= 0 && i < source.Count)
    					yield return source[i];
    			}
    		}
       }
    }
