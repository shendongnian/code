    var siteUrl = "https://your-sitecollection-url";
    var userName = "userName";
    var password = "password";
    
    using (ClientContext clientContext = new ClientContext(siteUrl))
    {
    	SecureString securePassword = new SecureString();
    	foreach (char c in password.ToCharArray())
    	{
    		securePassword.AppendChar(c);
    	}
    
    	clientContext.AuthenticationMode = ClientAuthenticationMode.Default;
    	clientContext.Credentials = new SharePointOnlineCredentials(userName, securePassword);
    	
    	clientContext.ExecuteQuery();
    
    	var ServerVersion = clientContext.ServerLibraryVersion.Major;
                    
    	var site = clientContext.Site;
    	var web = clientContext.Site.RootWeb;
    
    	clientContext.Load(web, w => w.ServerRelativeUrl);
    	clientContext.ExecuteQuery();
    
    	var serverRelativeUrl = clientContext.Site.RootWeb.ServerRelativeUrl;
    }
