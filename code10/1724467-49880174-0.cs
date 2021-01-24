    public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseKestrel(options => 
                    {
                        options.Listen(IPAddress.Any,44333, listenOptions =>
                        {
                          listenOptions.UseHttps("Path to SSL certificate","SSL Cert Password");
                            }
    
                        });
                    })
                    .UseStartup<Startup>()
                    .Build();
