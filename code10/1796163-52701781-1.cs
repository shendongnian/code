	public class Foo : IEquatable<Foo>
	{
		public string Bar { get; set; }
		
		public bool Equals(Foo other)
		{
			return other.Bar == this.Bar;
		}
	}
	
	public static void Main()
	{
		var list = new List<Foo>
		{
			new Foo { Bar = "Baz" }
		};
		
		Console.WriteLine(list.Contains(new Foo { Bar = "Baz" }));
	}
