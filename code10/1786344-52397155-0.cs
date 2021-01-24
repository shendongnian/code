    public class Startup
    {
    	public Startup(IConfiguration configuration)
    	{
    		Configuration = configuration;
    	}
    
    	public IConfiguration Configuration { get; }
    
    	// This method gets called by the runtime. Use this method to add services to the container.
    	public void ConfigureServices(IServiceCollection services)
    	{
    		services.AddMvc()
    			.AddJsonOptions(options =>
    		{
    			options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    			options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;                
    		});
    
    		services.AddCors();
    	}
    
    	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    	public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
    	{ 
    		app.UseCors(options =>
    		{
    			options.AllowAnyMethod();
    			options.AllowAnyOrigin();
    			options.AllowAnyHeader();
    		});
    
    		app.UseMvc();
    	}	
    }
