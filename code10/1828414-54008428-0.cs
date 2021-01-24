	void Main()
	{
		var foo = new Foo();
		
		foo.GetType().GetProperty("MyProp").SetValue(foo, "Test");
		var val = foo.GetType().GetProperty("MyProp").GetValue(foo);
		
		Console.WriteLine(val);
	}
	
	public class Foo
	{
		public String MyProp { get; set; }
	}
