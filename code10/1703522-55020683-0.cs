    public static void Main(string[] args)
    {
          //CreateWebHostBuilder(args).Build().Run();
          var host = CreateWebHostBuilder(args).Build();
          using (var scope = host.Services.CreateScope())
          {
                var services = scope.ServiceProvider;
                try
                {
                      var context = services.GetRequiredService<AppDbContext>();
                      //context.Database.EnsureCreated();
                      DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                      var logger = services.GetRequiredService<ILogger<Program>>();
                      logger.LogError(ex, "An error occurred creating the DB.");
                }
          }
          host.Run();
    }
