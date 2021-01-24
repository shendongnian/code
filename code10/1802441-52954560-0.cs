        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            {
             return  WebHost.CreateDefaultBuilder(args)
                        .ConfigureLogging(logging =>
                        {
                            logging.ClearProviders();
                            logging.SetMinimumLevel(LogLevel.Trace);
                        }).UseNLog()
                    .UseStartup<Startup>();
            }
