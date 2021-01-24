	public class Application
	{
		protected readonly IFactory _factory;
		
		public Application(IFactory factory)
		{
			_factory = factory;
		}
		
		public void Run()
		{
			var instance = _factory.Resolve("MyLibrary.dll", "External.DerivedClass");
			//Do something with instance
		}
	}
