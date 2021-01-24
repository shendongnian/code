    public static void Main(string[] args)
    {
        var host = WebHost.CreateDefaultBuilder(args)
                    //.UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();
        host.Run();
    }
