    public void SetUpHttpClients(IServiceCollection services)
    {
        var basePath = Directory.GetCurrentDirectory();
        var certificatePath = Path.Combine(basePath, CertPath);
        var fileExists = File.Exists(certificatePath);
        if (!fileExists)
            throw new ArgumentException(certificatePath);
        var certificate = new X509Certificate2(certificatePath, CertPwd);
        services.AddHttpClient("TestClient", client =>
        {
            client.BaseAddress = new Uri(BaseApi);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Accept));
            client.DefaultRequestHeaders.Add("ApiKey", ApiKey);
        }).ConfigurePrimaryHttpMessageHandler(() =>
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(certificate);
            return handler;
        });
    }
