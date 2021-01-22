    public static string Concatenate(
        this IEnumerable<string> collection, 
        string separator)
    {
    	return string.Join(separator, collection.ToArray());
    }
