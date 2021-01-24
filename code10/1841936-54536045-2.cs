	public enum AlphaType
	{
		A1,
		A2
	}
	
	public enum BetaType
	{
		B1,
		B2
	}
	
	public class Item<T>
	{
		public T Value { get; set; }
		public string Foo { get; set;}
	}
	
	public static void Main()
	{
		var item1 = new Item<AlphaType> { Value =  AlphaType.A1, Foo = "example 1" };
		var item2 = new Item<BetaType> { Value =  BetaType.B1, Foo = "example 2" };
		
		PrintAlphaFoo(item1);
		PrintAlphaFoo(item2);
	}
	
	public static void PrintAlphaFoo<T>(Item<T> item)
	{
		if (item.Value.GetType() == typeof(AlphaType) && item.Value.Equals(AlphaType.A1))
		{
			Console.WriteLine(item.Foo);
		}
	}
