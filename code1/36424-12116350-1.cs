    string result = string.Empty;
    
    UsingServiceClient.Do(
        new MyServiceClient(),
        client =>
        result = client.GetServiceResult(parameters));
