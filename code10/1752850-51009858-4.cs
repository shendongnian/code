    public void ConfigureServices(IServiceCollection services) {
        //...
        
        SetUpHttpClients(services);
        //...
        
        services.AddMvc();
    }
    
    public void SetUpHttpClients(IServiceCollection services) {
        var basePath = Directory.GetCurrentDirectory();
        var certificatePath = Path.Combine(basePath, certPath);
        var fileExists = File.Exists(certificatePath);
        if (!fileExists)
            throw new ArgumentException(certificatePath);
        var certificate = new X509Certificate2(certificatePath, certPwd);
        
        //Adding a named client
        services.AddHttpClient("TestClient", client => {
            client.BaseAddress = new Uri(baseApi);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(accept));
            client.DefaultRequestHeaders.Add("ApiKey", apiKey);
        })
        .ConfigurePrimaryHttpMessageHandler(() => {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler {
                CookieContainer = cookieContainer
            };
            handler.ClientCertificates.Add(certificate);
            return handler;
        });
    }
    
