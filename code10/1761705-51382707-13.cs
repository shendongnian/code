    public class Startup
    {
        IConfiguration Configuration;
        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SupplyApiClientHttpSettings>(Configuration);
            services.AddScoped<CustomerService>();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();
        }
    }
