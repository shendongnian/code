	public static void NonGenericMethod(A item)
	{
		Console.WriteLine("Method A");
		var typeOf = typeof(A);
		var getType = item.GetType();
	}
	public static void NonGenericMethod(B item)
	{
		Console.WriteLine("Method B");
		var typeOf = typeof(B);
		var getType = item.GetType();
	}
