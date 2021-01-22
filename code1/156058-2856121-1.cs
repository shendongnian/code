	class TestThing<T>
	{
		public void SomeMethod(string message, T data)
		{
			Console.WriteLine("first");
		}
		public void SomeMethod(string message, params T[] data)
		{
			Console.WriteLine("second");
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			var item = new object();
			var test_thing = new TestThing<object>();
			test_thing.SomeMethod("woohoo", item);
			test_thing.SomeMethod("woohoo", item, item);
			Console.ReadLine();
		}
	}
