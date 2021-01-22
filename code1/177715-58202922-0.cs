    public static class Extensions
    {
	    public static string ToStringInvariant<T>(this T obj)
	    {
    		return System.FormattableString.Invariant($"{obj}");
	    }
    }
