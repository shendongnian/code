    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       public void ConfigureServices(IServiceCollection services)
       {
        services.AddMvc();
        services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));
       }
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();
        app.UseMvc();
        var settingsSection = Configuration.GetSection("DatabaseSettings");
        var settings = settingsSection.Get<DatabaseSettings>();
        Mongo.Initialize("mongodb://" + settings.Hostname + ":" + settings.Port, settings.DbName);
      }
    }
