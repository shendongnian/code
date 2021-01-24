        public sealed class Startup
        {
            private readonly IConfiguration configuration;
            public Startup(IConfiguration configuration) => this.configuration = configuration;
            public void ConfigureServices(IServiceCollection services)
            {
                services
                    .Configure<EmailSettings>(configuration)
                    .AddSingleton(sp => sp.GetRequiredService<IOptions<EmailSettings>>().Value);
            }
        }
