    class AppServiceBuilder
    {
    	public ServiceCollection Services { get; } = new ServiceCollection();
    	public AppServiceProvider Build() => new AppServiceProvider(Services.BuildServiceProvider());
    }
    
    class AppServiceProvider
    {
    	public AppServiceProvider(IServiceProvider services) { Services = services; }
    	public IServiceProvider Services { get; }
    }
    class Program
    {
        // ...
    
        static void Main(string[] args)
        {
             CreateWebHostBuilder(args).Build().Services.GetService<TheApp>().Run();
        }
        
        // This "WebHostBuilder" will be used by EF Core design time tools :)
        static AppServiceBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = new AppServiceBuilder();
            ConfigureServices(builder.Services);
            return builder;
        }
    }
