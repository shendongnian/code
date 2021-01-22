    public static Tuple<int, int> Sum<T>(this IEnumerable<T> collection, Func<T, int> selector1, Func<T, int> selector2)
	{
		int a = 0;
		int b = 0;
		
		foreach(var i in collection)
		{
			a += selector1(i);
			b += selector2(i);
		}
		
		return Tuple.Create(a, b);
	}
