           public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    options.Limits.MinRequestBodyDataRate =
                        new MinDataRate(bytesPerSecond: 80, gracePeriod: TimeSpan.FromSeconds(20));
                    options.Limits.MinResponseDataRate =
                        new MinDataRate(bytesPerSecond: 80, gracePeriod: TimeSpan.FromSeconds(20));
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog()
                .UseStartup<Startup>()
                .Build();
    }
