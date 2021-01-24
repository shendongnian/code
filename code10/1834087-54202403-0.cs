    public class GenericWebApplicationFactory<TStartup, TContext, TSeed>
        : WebApplicationFactory<TStartup>
        where TStartup : class
        where TContext : DbContext
        where TSeed : class, ISeedDataClass
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.UseEnvironment("Development");
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();
                services.AddSingleton<ISeedDataClass,TSeed >();
                services.AddDbContextPool<TContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(serviceProvider);
                    options.EnableSensitiveDataLogging();
                });
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<TContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<GenericWebApplicationFactory<TStartup, TContext, TSeed>>>();
                    var seeder = scopedServices.GetRequiredService<ISeedDataClass>();
                    db.Database.EnsureCreated();
                    try
                    {
                        seeder.InitializeDbForTests();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
