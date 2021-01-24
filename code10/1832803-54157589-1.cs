    public static void Main(string[] args)
    {
         CurrentDirectoryHelpers.SetCurrentDirectory(); // call it here
        IWebHostBuilder builder = new WebHostBuilder();
        builder.ConfigureServices(s =>
        {
            s.AddSingleton(builder);
        });
        builder.UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseStartup<Startup>()
               .UseUrls("http://localhost:9000");
        var host = builder.Build();
        host.Run();
    }
