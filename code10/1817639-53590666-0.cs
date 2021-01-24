    var clientHandler = new HttpClientHandler();
    clientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
    clientHandler.ClientCertificates.Add(_deviceCertificate);
    var client = new HttpClient(clientHandler);
    var result = client.GetAsync("https://yourservice.com").GetAwaiter().GetResult();
