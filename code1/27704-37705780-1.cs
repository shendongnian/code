    public static class MiscExctensions
    {
	    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int nbItems)
	    {
		    return (
			    list
			    .Select((o, n) => new { o, n })
			    .GroupBy(g => (int)(g.n / nbItems))
			    .Select(g => g.Select(x => x.o))
		    );
	    }
    }
