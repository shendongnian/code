        public void ConfigureServices(IServiceCollection services)
        {
            services
                 .Configure<EmailSettings>(configuration)
                 .AddSingleton(sp => sp.GetRequiredService<IOptions<EmailSettings>>().Value);
        }
