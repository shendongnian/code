    public static int CompareValue(object a, object b)
    	{
    		if (a is IComparable && b is IComparable)
    		{
    			 return ((IComparable)a).CompareTo((IComparable)b);
    		}
    		return -2; // not correct type
    	}
