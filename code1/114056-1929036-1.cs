    public static class Singleton<T>
    {
    	private static T instance;
    	private static readonly object sync = new object();
    	static bool registered = false;
    
    	public static T Instance
    	{
    		get
    		{
    			return instance;
    		}
    	}
    
    	public static void Register(Func<T> constructor)
    	{
    		lock (sync)
    		{
    			if (!registered)
    			{
    				instance = constructor();
    				registered = true;
    			}
    		}
    	}
    }
    
    class Demo
    {
    	class Data
    	{
    		public string Pass { get; set; }
    		public string Login { get; set; }
    	}
    
    	void SimpleUsage()
    	{
    		string login = "SEKRIT";
    		string pass = "PASSWORD";
    
    		// setup 
    		Singleton<Data>.Register(() => new Data { Login = login, Pass = pass });
    
    		// 
    		var ltCommander = Singleton<Data>.Instance;
    	}
    
    	/// <summary>
    	/// Using an interface will make the singleton mockable for tests! 
    	/// That's invaluable when you'll want to fix something FAST without running the whole app!
    	/// </summary>
    	interface IData
    	{
    		string Login { get; }
    		string Password { get; }
    	}
    
    	class UnitTestFriendlyData : IData
    	{
    		public UnitTestFriendlyData(string login, string password)
    		{
    			Login = login;
    			Password = password;
    		}
    
    
    		public string Login { get; private set; }
    		public string Password { get; private set; }
    	}
    
    	void SmarterUsage()
    	{
    		// same setup, but through the interface. 
    		Singleton<IData>.Register(() => new UnitTestFriendlyData("login", "pass"));
    
    		// and same for the retrieval
    		var data = Singleton<IData>.Instance;
    
    	}
    
    	
    	void UnitTestSetupWithMoq()
    	{
    		// Register a mock.
    		var mock = new Mock<IData>();
    		mock.SetupProperty(x => x.Login, "Login");
    		mock.SetupProperty(x => x.Pass, "Pass");
    		Singleton<IData>.Register(() => mock.Object);
    
    		// and same for the retrieval
    		var data = Singleton<IData>.Instance;
    
    	}
    
    }
