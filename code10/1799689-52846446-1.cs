    public static class ZipEx
    {
    	public static IEnumerable<IEnumerable<T>> ZipAll<T>(
                                       this IEnumerable<IEnumerable<T>> src)
    	{
    		return src
    			.Aggregate(
    				(IEnumerable<IEnumerable<T>>)null,
    				(acc, curr) => acc == null
    					? curr.Select(x => x.ToEnumerable())
    					: acc.Zip(curr, (a, c) => a.Append(c)));
    	}
    	public static IEnumerable<T> ToEnumerable<T>(this T item)
    	{
    		yield return item;
    	}
    }
