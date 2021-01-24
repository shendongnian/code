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
            //Rest Code
            ConfigureHangfire(services);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Rest Code
            app.UseHangfireServer();
            RecurringJob.AddOrUpdate(() => Console.WriteLine("RecurringJob!"), Cron.Minutely);
        }
        protected virtual void ConfigureHangfire(IServiceCollection services)
        {
            services.AddHangfire(config =>
              config.UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"))
            );
        }
        }
