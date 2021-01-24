    using Microsoft.Extensions.DependencyInjection;
    using NLog.Extensions.Logging;
    using NLog.Web;
    
    public class Startup
    {
      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
    	services.AddMvc();
        services.AddSession(); // After AddMvc()
    	services.AddHttpContextAccessor();
      }
    
      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
      {
        app.UseSession();  // Before UseMvc()
        app.UseMvc();
    	app.ApplicationServices.SetupNLogServiceLocator();
    	loggerFactory.AddNLog();
      }
    }
