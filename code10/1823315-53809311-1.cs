    //using IdentityModel.Client;
    var client = new HttpClient();
    var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
    if (disco.IsError)
    {
        Console.WriteLine(disco.Error);
        return;
    }
    // request token
    var tokenResponse = await client.RequestClientCredentialsTokenAsync(
                              new ClientCredentialsTokenRequest
                              {
                                  Address = disco.TokenEndpoint,
                
                                  ClientId = "client",
                                  ClientSecret = "secret",
                                  Scope = "api1"
                              });
    if (tokenResponse.IsError)
    {
        Console.WriteLine(tokenResponse.Error);
        return;
    }
