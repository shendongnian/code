    public static class EnumearbleExtensions
    {
    	public static IEnumerable<T> UnWrap<T>(this IEnumerable<IEnumerable<T>> list)
    	{
    		foreach(var innerList in list)
    		{
    			foreach(T item in innerList)
    			{
    				yield return item;
    			}
    		}
    	}
    }
