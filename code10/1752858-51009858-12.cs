    var serviceProvider = services.BuildServiceProvider();
    var factory = serviceProvider.GetService<IHttpClientFactory>();
    var client = factory.CreateClient("TestClient");
    
    var body = new { Username = username, Password = password };
    var jsonBody = JsonConvert.SerializeObject(body);
    var content = new StringContent(jsonBody, Encoding.UTF8, contentType);
    var loginResponse = client.PostAsync("api/authentication", content).Result;
    
    //...do something with the response
    
