    public class Startup
    {
        private readonly IConfiguration config;
        public Startup(IConfiguration config)
        {
            this.config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TestDataContext>(
                options => options.UseSqlServer(this.config.GetConnectionString("TestConnectionString")),
                ServiceLifetime.Singleton);
            services.AddScoped<IEFDatabaseContext>(provider => provider.GetService<TestDataContext>());
        }
    }
