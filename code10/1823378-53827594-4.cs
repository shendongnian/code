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
                services.AddTransient<DbConnection>(serviceProvider => new DbConnection(Configuration.GetConnectionString("DefaultConnection")));
                services.AddMvc();
                // your rest configure services
                
                services.AddTransient<ISecuritySettingService, SecuritySettingService>();
                services.AddTransient<ISecuritySettingRepository, SecuritySettingRepository>();
                var _ecuritySettingService = services.BuildServiceProvider().GetRequiredService<ISecuritySettingService>();
                services.Configure<IdentityOptions>(options =>
                {
                    options.Lockout.MaxFailedAccessAttempts = _ecuritySettingService.GetSecuritySetting()?.MaxFailedAccessAttempts ?? 3;
                });
            }
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                //your configure
            }
        }
