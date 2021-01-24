    public class Startup
    {
    	static IServiceProvider _serviceProvider;
    	static string GetUserIp()
    	{
    		return _serviceProvider.GetService<IHttpContextAccessor>()
                .HttpContext.Connection.RemoteIpAddress.ToString();
    	}
    	// This method gets called by the runtime. Use this method to add services to the container.
    	public void ConfigureServices(IServiceCollection services)
    	{
    		services.AddHttpContextAccessor();
    		...
    	}
    	public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    	{
    		_serviceProvider = app.ApplicationServices;
    		LoggerDll.UserIpGetter = GetUserIp;
    		...
    	}
    }
