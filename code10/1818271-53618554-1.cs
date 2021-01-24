    var clientCred = new ClientCredential("<client id>",  "<secret>");
    var authContext = new AuthenticationContext("https://login.windows.net/" + "<b2c tenant>");
    var authResult = authContext.AcquireTokenAsync("https://graph.microsoft.com/", clientCred).Result;
            var client = new GraphServiceClient(
                new DelegateAuthenticationProvider(
                    async (requestMessage) =>
                    {
                        var token = authResult.AccessToken;
                        var result = await Task.FromResult(token);
            
                        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
                    }));
            //Change to the beta version
            client.BaseUrl = "https://graph.microsoft.com/beta";
            //Parameters of the query
             List<QueryOption> options = new List<QueryOption> { new QueryOption("$Expand", "MemberOf") };
            // query with parameters
             var users = graphClient.Users.Request(options).GetAsync().Result.ToList();
