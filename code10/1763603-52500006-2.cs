    services.AddHttpClient("YourApiName", client =>
    {
        client.BaseAddress = new Uri("The base address of your api");
        client.DefaultRequestHeaders.Add("Accept", "application/json");
        client.DefaultRequestHeaders.Add("User-Agent", "The application name of your client");
        client.DefaultRequestHeaders.Add("ApplicationId", "The application id of your client");
    });
