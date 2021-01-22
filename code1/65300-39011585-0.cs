	public static IEnumerable<T> CreateEnumerable<T>(params T[] items)
	{
        if(items == null)
            yield break;
	    foreach (T mitem in items)
	        yield return mitem;
	}
