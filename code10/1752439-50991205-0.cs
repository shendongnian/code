    services.AddHttpClient("TestClient", client => {
        client.BaseAddress = new Uri(baseApi);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(accept));
        client.DefaultRequestHeaders.Add("ApiKey", apiKey);
    })
    .ConfigurePrimaryHttpMessageHandler(() => {
        var handler = new HttpClientHandler {
            CookieContainer = cookieContainer
        };
        handler.ClientCertificates.Add(certificate);
        return handler;
    });
