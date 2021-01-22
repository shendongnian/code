    class MyClass {}
	static class MyClassExtensions
	{
		public static void DoSomething<T>(this T item, List<string> someList)
		{
			Console.WriteLine("Method with List in signature is called.");	
		}
		public static void DoSomething<T>(this T item, IEnumerable<string> someEnumerable)
		{
			Console.WriteLine("Method with IEnumerable in signature is called.");	
		}
	}
