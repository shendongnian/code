    CreateWebHostBuilder(args)
        .MigrateDbContext<ApplicationDbContext>((context, services) =>
        {
            var env = services.GetService<IHostingEnvironment>();
            var logger = services.GetService<ILogger<ApplicationDbContextSeed>>();
            new ApplicationDbContextSeed()
                .SeedAsync(context, env, logger)
                .Wait();
        }).Build().Run(); //<-- HERE
