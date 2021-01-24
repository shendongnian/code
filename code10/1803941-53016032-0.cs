    public class Startup
    {
    	private readonly IConfiguration _configuration;
    	
    	public Startup(IHostingEnvironment env)
    	{
    		var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
    		_configuration = builder.Build();
    	}
    		
    	// This method gets called by the runtime. Use this method to add services to the container.
    	// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    	public void ConfigureServices(IServiceCollection services)
    	{
    	}
    
    	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    	public void Configure(IApplicationBuilder app, 
    							IHostingEnvironment env, 
    							ILoggerFactory loggerFactory)
    	{
    		loggerFactory.AddConsole();
    
    		if (env.IsDevelopment())
    		{
    			app.UseDeveloperExceptionPage();
    		}
    
    		app.Run(async (context) =>
    		{
    			var greeting = _configuration["Greeting"];
    			await context.Response.WriteAsync(greeting);
    		});
    	}
    }
