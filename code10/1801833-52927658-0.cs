    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // register other things here...
            services.AddDbContext<DataContext>(o => o.UseSqlServer(
                config.GetConnectionString("MyConnectionString") // from appsettings.json
            ));
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // set up app here...
        }
    }
