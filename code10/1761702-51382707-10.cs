    public class Startup
    {
        IConfiguration Configuration; 
        public Startup()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
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
