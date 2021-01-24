    internal static class Program
    {
    	public static void Main(String[] args)
    	{
    		void StartListeningSomething()
    		{
    			Task.Factory.StartNew(() =>
    			{
    				while (true)
    				{
    					Log.Information("Listening");
    					Thread.Sleep(500);
    				}
    			}, TaskCreationOptions.LongRunning);
    		}
    
    		Log.Logger = new LoggerConfiguration()
    			.Enrich.WithThreadId()
    			.Filter.ByExcluding(logEvent => logEvent.IsSuppressed()) // Check if log event marked with supression property
    			.Enrich.FromLogContext()
    			.WriteTo.Console(new JsonFormatter())
    			.CreateLogger();
    
    		using (SerilogExtensions.SuppressLogging())
    		{
    			StartListeningSomething();
    			Console.ReadKey(); // Will ignore background thread log messages until some key is entered
    		}
    
    		// Will start logging events after exiting the using block
    
    		Console.ReadKey();
    	}
    }
