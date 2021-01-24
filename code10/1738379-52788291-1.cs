    void Main() 
    {
        m_server = new FakeServer();
        var builder = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder()
            .UseStartup<InternalServerStartup>()
            .UseSetting(WebHostDefaults.SuppressStatusMessagesKey, "True")
            .ConfigureServices(services => {
                services.AddSingleton<IServer>(m_server); // this causes the WebHostBuilder to fire requests at our fake server
            });
        var host = builder.Build();
        host.Start();
    }
    // This class solely exists for us capture the instance of HostingApplication that MVC creates internally so we can invoke it directly
    protected class FakeServer : IServer
    {
        public HostingApplication HostingApplication { get; private set; } = null;
        public IFeatureCollection Features => new FeatureCollection();
        public void Dispose()
        { }
        public Task StartAsync<TContext>(IHttpApplication<TContext> application, CancellationToken cancellationToken)
        {
            if(application is HostingApplication standardContextApp) {
                HostingApplication = standardContextApp;
            }
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
    TunneledResponse OnTunneledRequest(string url, string method, string[] headers, byte[] body)
    {
        var host = m_server.HostingApplication;
        var responseBodyStream = new MemoryStream();
        var features = new FeatureCollection();
        features.Set<IHttpRequestFeature>(new HttpRequestFeature());
        features.Set<IHttpResponseFeature>(new HttpResponseFeature { Body = responseBodyStream });
        var ctx = host.CreateContext(features);
        var httpContext = ctx.HttpContext;
        var targetUri = new Uri(url);
        httpContext.Request.Scheme = "fakescheme";
        httpContext.Request.Host = new HostString("fakehost"); // if host is missing, things crash down the line: https://github.com/aspnet/Home/issues/2718
        httpContext.Request.Path = targetUri.AbsolutePath;
        httpContext.Request.Method = method;
        httpContext.Request.QueryString = new QueryString(targetUri.Query);
        for (var i = 0; i < headers.Length / 2; i++)
            httpContext.Request.Headers.Add(headers[i * 2], headers[i * 2 + 1]);
        try { 
            await host.ProcessRequestAsync(ctx);
            responseBodyStream.Position = 0; // aspnet will have written to it, seek back to the start
                
            return new TunneledResponse {
                statusCode = httpContext.Response.StatusCode,
                headers = httpContext.Response.Headers.SelectMany(h => new[] { h.Key, h.Value.FirstOrDefault() }).ToArray(),
                body = responseBodyStream.ToArray()
            };
        }
    }
