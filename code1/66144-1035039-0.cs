    public static class IEnumerableExtensions
    {
    	public static IEnumerable<List<T>> InSetsOf<T>(this IEnumerable<T> source, int max)
    	{
    		List<T> toReturn = new List<T>();
    		foreach(var item in source)
    		{
    			toReturn.Add(item);
    			if (toReturn.Count == max)
    			{
    				yield return toReturn;
    				toReturn = new List<T>();
    			}
    		}
    		if (toReturn.Any())
    		{
    			yield return toReturn;
    		}
    	}
    }
