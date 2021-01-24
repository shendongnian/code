	public static void Main()
	{
		var foo2 = new Foo2();
		foo2.Foo1Go();  //Write "1"
		foo2.Foo2Go();  //Writes "2" then "1"
	}
	
	public class Foo1
	{
		private class Bar { public int Id { get; private set; } = 1; }
		
		private Bar bar = new Bar();
		
		public void Foo1Go()
		{
			Console.WriteLine(bar.Id);
		}
	}
	
	public class Foo2 : Foo1
	{
		private class Bar { public int Id { get; private set; } = 2; }
		
		private Bar bar = new Bar();
		public void Foo2Go()
		{
			Console.WriteLine(bar.Id);
			var foo1 = this as Foo1;
			foo1.Foo1Go();
		}
	}
