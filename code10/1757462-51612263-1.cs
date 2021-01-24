    public ClientContext GetAzureADAppOnlyAuthenticatedContext(string siteUrl, string clientId, string tenant, X509Certificate2 certificate)
    {
    	var clientContext = new ClientContext(siteUrl);
    
    	string authority = string.Format(CultureInfo.InvariantCulture, "https://login.windows.net/{0}/", tenant);
    
    	var authContext = new AuthenticationContext(authority);
    
    	var clientAssertionCertificate = new ClientAssertionCertificate(clientId, certificate);
    
    	var host = new Uri(siteUrl);
    
    	clientContext.ExecutingWebRequest += (sender, args) =>
    	{
    		var ar = authContext.AcquireTokenAsync(host.Scheme + "://" + host.Host + "/", clientAssertionCertificate).GetAwaiter().GetResult();
    		args.WebRequestExecutor.RequestHeaders["Authorization"] = "Bearer " + ar.AccessToken;
    	};
    
    	return clientContext;
    }
