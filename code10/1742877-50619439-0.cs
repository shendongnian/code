	public static class Program
    {
        public static void Main(string[] args)
        {
			var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
			try
			{
				var config = new ConfigurationBuilder()
						.SetBasePath(Directory.GetCurrentDirectory())
						.AddJsonFile("hosting.json", optional: true)
						.Build();
				BuildWebHost(args, config).Run();
			}
			catch (System.Exception ex)
			{
				logger.Error(ex, "An error occurred during program startup");
				throw;
			}
        }
        private static IWebHost BuildWebHost(string[] args, IConfigurationRoot config)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
				.UseStartup<Startup>()
				.UseNLog()
                .Build();
        }
	}
