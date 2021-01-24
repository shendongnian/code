    string odataUrl = "https://org.crm6.dynamics.com/api/data/v8.2/"; // trailing slash actually matters
    string appId = "some-guid";
    string clientSecret = "some key";
    AuthenticationParameters authArg = AuthenticationParameters.CreateFromResourceUrlAsync(new Uri(odataUrl)).Result;
    AuthenticationContext authCtx = new AuthenticationContext(authArg.Authority);
    AuthenticationResult authRes = authCtx.AcquireTokenAsync(authArg.Resource, new ClientCredential(appId, clientSecret)).Result;
    using (HttpClient client = new HttpClient()) {
      client.TimeOut = TimeSpan.FromMinutes (2);
      client.DefaultRequestHeaders.Add("Authorization", authRes.CreateAuthorizationHeader ());
      using (HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, $"{odataUrl}accounts?$select=name&$top=10")) {
        using (HttpResponseMessage res = client.SendAsync(req).Result) {
          if (res.IsSuccessStatusCode) {
            Console.WriteLine(res.Content.ReadAsStringAsync().Result);
          }
          else {
            // cry
          }
        }
      }
    }
