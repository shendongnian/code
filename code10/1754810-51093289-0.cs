	static public class MyClass
	{
		static bool _initialized = false;
		
		static MyClass()
		{
			Console.WriteLine("Test.ctor called");
		}
		
		static void Initialize()
		{
			Console.WriteLine("Test.Initialize called");
            _initialized = true;
		}
		
		static public event EventHandler MyEvent;
		
		static public void RaiseMyEvent()
		{
			if (!_initialized) Initialize();
			if (MyEvent != null) MyEvent(typeof(MyClass), new EventArgs());
		}
	}
