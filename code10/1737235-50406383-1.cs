            public Startup(IHostingEnvironment env)
            {
                Configuration = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
    
                HostingEnvironment = env;
            }
    
            public IConfigurationRoot Configuration { get; }
            public IHostingEnvironment HostingEnvironment { get; }
    
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                if (HostingEnvironment.IsDevelopment())
                {
                    services.AddDbContext<SchoolContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                }
                else
                {
                    services.AddDbContext<SchoolContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("azure")));
                }
                services.AddMvc();
            }
