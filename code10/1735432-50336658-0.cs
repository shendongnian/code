    public static class ExtensionMethods
    {
        public static IEnumerable<T> Last<T>(this IEnumerable<T> This, int count)
	    {
    		return This.Reverse().Take(count).Reverse();
	    }
    }
