    public static IEnumerable<Pair<Int32, X>> Ordinate<X>(this IEnumerable<X> lhs)
    {
    	return lhs.Ordinate(0);
    }
    
    public static IEnumerable<Pair<Int32, X>> Ordinate<X>(this IEnumerable<X> lhs, Int32 initial)
    {
    	Int32 index = initial - 1;
    
    	foreach (X x in lhs)
    	{
    		++index;
    		yield return new Pair<Int32, X>(index, x);
    	}
    }
