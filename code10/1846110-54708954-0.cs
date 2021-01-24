    public static class Program
    {
        public static void Main(string[] args)
        {
			var provider = new ServiceCollection()
						.AddLogging()
						.AddSingleton<IFooService, FooService>()
						.AddSingleton<IMonitor, MyMonitor>()
						.BuildServiceProvider();
			
			ServiceRuntime.RegisterServiceAsync("MyServiceType",
				context => new MyService(context, provider.GetService<IMonitor>());
			}).GetAwaiter().GetResult();
