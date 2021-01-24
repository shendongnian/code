	public class MyBase
	{
		protected Action Foo()
		{
			return Local;
			
			void Local()
			{
				Console.WriteLine("Hello world");
			}
		}
	}
	
	public class MyDerived : MyBase
	{
		public void HelloWorld()
		{
			var f = Foo();
			f();
		}
	}
	
	
	public class Program
	{
		public static void Main()
		{
			var o = new MyDerived();
			o.HelloWorld();
		}
	}
