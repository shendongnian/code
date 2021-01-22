    public static void Match<T>(this IList<T> collection, Action<T,T> block)
    {
    	block(collection[0], collection[1]);
    }
    public static void Match<T>(this IList<T> collection, Action<T,T,T> block)
    {
    	block(collection[0], collection[1], collection[2]);
    }
    //...
	
