    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
    
            Configuration = builder.Build();
        }
    
        public static IConfiguration Configuration { get; private set; }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    
            services.AddOptions<ActivationServiceOptions>(Configuration);
    
            services.AddScoped<ActivationServiceContext>();
            services.AddOptions<ActivationServiceContextOptions>(Configuration);
    
            services.AddOptions<KeysProviderOptions>(Configuration);
            services.AddScoped<IEncryptor, Encryptor>();
    
            LandingLoggingStartup.ConfigureServices(services, Configuration);
        }
    
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
    
            LandingLoggingStartup.Configure(app);
            app.UseMvc();
        }
    }
