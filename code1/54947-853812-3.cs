    public static string Join<T>([CanBeNull] this IEnumerable<T> items, [CanBeNull] string delimiter)
    {
    	StringBuilder result = new StringBuilder();
    	if (items != null && items.Any())
    	{
    		delimiter = delimiter ?? "";
    		foreach (T item in items)
    		{
    			result.Append(item);
    			result.Append(delimiter);
    		}
    		result.Length = result.Length - delimiter.Length;
    	}
    	return result.ToString();
    }
