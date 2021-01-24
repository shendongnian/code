    public MyTestStartup()
    {
        _webhost = WebHost.CreateDefaultBuilder(null)
                          .UseStartup<Startup>()
                          .UseKestrel()
                          .UseUrls(BASE_URL)
                          .Build();
        _webhost.Start();
    }
