    public static IEnumerable<Pair<Int32, X>> Ordinate<X>(this IEnumerable<X> lhs)
    {
    	return lhs.Ordinate(0);
    }
    
    public static IEnumerable<Pair<Int32, X>> Ordinate<X>(this IEnumerable<X> lhs, Int32 initial)
    {
    	Int32 index = initial - 1;
    
    	return lhs.Select(x => new Pair<Int32, X>(++index, x));
    }
