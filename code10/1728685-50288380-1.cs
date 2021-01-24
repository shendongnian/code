    string odataUrl = "https://org.crm6.dynamics.com/xrmservices/2011/organization.svc/web?SdkClientVersion=8.2"; // don't question the url, just accept it.
    string appId = "some-guid";
    string clientSecret = "some key";
    AuthenticationParameters authArg = AuthenticationParameters.CreateFromResourceUrlAsync(new Uri(odataUrl)).Result;
    AuthenticationContext authCtx = new AuthenticationContext(authArg.Authority);
    AuthenticationResult authRes = authCtx.AcquireTokenAsync(authArg.Resource, new ClientCredential(appId, clientSecret)).Result;
    using (OrganizationWebProxyClient webProxyClient = new OrganizationWebProxyClient(new Uri(orgSvcUrl), false)) {
      webProxyClient.HeaderToken = authRes.AccessToken;
      using (OrganizationServiceContext ctx = new OrganizationServiceContext((IOrganizationService)webProxyClient)) {
        var accounts = (from i in ctx.CreateQuery("account") orderby i["name"] select i).Take(10);
        foreach (var account in accounts)
          Console.WriteLine(account["name"]);
      }
    }
