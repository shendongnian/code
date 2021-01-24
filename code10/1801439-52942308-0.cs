            public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    // Configure the app here.
                })
                .UseKestrel((context, options) =>
                {
                    options.ListenAnyIP(5001, listenOptions =>
                    {
                        listenOptions.UseHttps(httpsOptions =>
                        {
                            var cert = CertificateLoader.LoadFromStoreCert(
                                "localhost", "My", StoreLocation.LocalMachine,
                                allowInvalid: true);
                            httpsOptions.ServerCertificateSelector = (connectionContext, name) =>
                            {
                                return cert;
                            };
                        });
                    });
                })
                .UseContentRoot(pathToContentRoot)
                .UseStartup<Startup>();
        }
