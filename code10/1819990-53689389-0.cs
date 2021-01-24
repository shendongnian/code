    public static void Main(string[] args)
            {
                var hostBuilder = CreateWebHostBuilder(args);
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                
                if (!string.IsNullOrEmpty(env) && env.Equals("Production"))
                {
                    hostBuilder.ConfigureLogging((context, builder) =>
                    {
                        // Read GelfLoggerOptions from appsettings.json
                        builder.Services.Configure<GelfLoggerOptions>(context.Configuration.GetSection("Graylog"));
    
                        // Optionally configure GelfLoggerOptions further.
                        builder.Services.PostConfigure<GelfLoggerOptions>(options =>
                            options.AdditionalFields["machine_name"] = Environment.MachineName);
    
                        // Read Logging settings from appsettings.json and add providers.
                        builder.AddConfiguration(context.Configuration.GetSection("Logging"))
                            .AddConsole()
                            //.AddDebug()
                            .AddGelf();
                    });
                }
    
                var host = hostBuilder.Build();
                
                using (var scope = host.Services.CreateScope())
                {
                    try
                    {
                        // Retrieve your DbContext isntance here
                        var dbContext = scope.ServiceProvider.GetRequiredService<NozomiDbContext>();
    
                        if (env != null && !env.Equals("Production"))
                        {
                            dbContext.Database.EnsureDeleted();
                            dbContext.Database.EnsureCreated();
                        }
                        else
                        {
                            dbContext.Database.SetCommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                            dbContext.Database.Migrate();
                        }
                        // place your DB seeding code here
                        //DbSeeder.Seed(dbContext);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex); 
                        // Continue
                    }
                }
                
                host.Run();
            }
