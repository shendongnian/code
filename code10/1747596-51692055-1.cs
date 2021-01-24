      public static async Task Main(string[] args)
      {
        var host = BuildWebHost(args);
        using (var scope = host.Services.CreateScope())
        {
          var services = scope.ServiceProvider;
          Console.WriteLine(services.GetService<IConfiguration>().GetConnectionString("DefaultConnection"));
          try
          {
            var context = services.GetRequiredService<PdContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var dbInitializerLogger = services.GetRequiredService<ILogger<DbInitializer>>();
            await DbInitializer.Initialize(context, userManager, roleManager, dbInitializerLogger);
          }
          catch (Exception ex)
          {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while migrating the database.");
          }
        }
        host.Run();
      }
      public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .Build();
    }
