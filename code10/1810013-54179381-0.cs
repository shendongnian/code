        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
                builder.UseKestrel()
                .UseSolutionRelativeContentRoot("")
                .ConfigureAppConfiguration((context, configBuilder) =>
                {
                  // Config code
                })
                .UseStartup<Startup>();
        }
