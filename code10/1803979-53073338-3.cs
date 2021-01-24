	public class Program
	{
    	static Ref<Foo> _container = new Ref<Foo>(null);
		static void MyMethod(Ref<Foo> thisArg) 
		{
			Action action = () => thisArg.Value = new Foo("After");
			action();
		}
		public static void Main()
		{
			_container.Value = new Foo("Before");
			Console.WriteLine("Value before  call is: {0}", _container);
			MyMethod(_container);
			Console.WriteLine("Value after call is: {0}", _container);
		}
	}
