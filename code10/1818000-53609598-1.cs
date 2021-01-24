     public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        //HostingEnvironment = hostingContext.HostingEnvironment;
    
                        //config.SetBasePath(HostingEnvironment.ContentRootPath);
                        var workingDirectory = AppContext.BaseDirectory; // HostingEnvironment.ContentRootPath // Directory.GetCurrentDirectory()
                        foreach (var file in Directory.GetFiles(workingDirectory, "*_config.json"))
                        {
                            config.AddJsonFile(file);//);Path.GetFileName(file));
                        }
                    })
                    .UseStartup<Startup>();
