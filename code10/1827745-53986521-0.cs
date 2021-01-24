    public class ServicesRootConfiguration
    {
    	public ServicesConfiguration ServicesConfiguration { get; set; }
    }
Startup.cs
    public class Startup
    {
    	private readonly IHostingEnvironment _hostingEnvironment;
    
    	public Startup(IConfiguration configuration, IHostingEnvironment env)
    	{
    		Configuration = configuration;
    		_hostingEnvironment = env;
    	}
    
    	public IConfiguration Configuration { get; }
    
    	public void ConfigureServices(IServiceCollection services)
    	{
    		// other configuration omitted for brevity
    		
    		// build your custom configuration from json files
    		var myCustomConfig = BuildCustomConfiguration(_hostingEnvironment);
    		
    		// Register the configuration as a Singleton
    		services.AddSingleton(myCustomConfig);
    	}
    
    	private static ServicesConfiguration BuildCustomConfiguration(IHostingEnvironment env)
    	{
    		var allConfigs = new List<ServicesRootConfiguration>();
    
    		var path = Path.Combine(env.ContentRootPath, "App_Config");
    
    		foreach (var file in Directory.EnumerateFiles(path, "*.json", SearchOption.AllDirectories))
    		{
    			var config = JsonConvert.DeserializeObject<ServicesRootConfiguration>(File.ReadAllText(file));
    			allConfigs.Add(config);
    		}
    
    		// do your logic to "merge" the each config into a single ServicesConfiguration
    		// here I simply select the AssemblyName from all files.
    		var mergedConfig = new ServicesConfiguration
    		{
    			Services = allConfigs.SelectMany(c => c.ServicesConfiguration.Services).ToList()
    		};
    
    		return mergedConfig;
    	}
    }
