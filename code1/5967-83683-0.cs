    public static IEnumerable<T> Reverse<T>(IEnumerable<T> items)
    {
    	IList<T> list = items as IList<T>;
    	if (list == null) list = new List<T>(items);
    	for (int i = list.Count - 1; i >= 0; i-- )
    	{
    		yield return list[i];
    	}
    }
