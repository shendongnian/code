        public static class WebHostBuilderExtension
    {
        public static IWebHostBuilder CustomExtension(this IWebHostBuilder webHostBuilder)
        {
            return webHostBuilder.ConfigureServices(services => {
                var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
                var connection = config.GetConnectionString("Default");
            });
        }
        public static void CustomAction(IServiceCollection services)
        {
            var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var connection = config.GetConnectionString("Default");
        }
    }
