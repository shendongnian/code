	public interface IFoo 
	{
		int GetFoo();
	}
	
	public class Foo : IFoo 
	{
		public int GetFoo()
		{
			var foo = ... // does something to get a foo
			return foo;
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			IFoo theFoo = new Foo();
			theFoo.PityTheFoo();       // wait, what?  
		}
	}
