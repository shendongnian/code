    public static IEnumerable<T> GetNth<T>(this IList<T> list, int n)
    {
    	for (int i = n - 1; i < list.Count; i += n)
    	    yield return list[i];
	}
