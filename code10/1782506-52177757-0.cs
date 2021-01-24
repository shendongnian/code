    var tenantAdminSiteUrl = "https://tenant-admin.sharepoint.com";
    var siteCollectionUrl = "https://tenant.sharepoint.com/sites/Test";
    
    var userName = "admin@tenant.onmicrosoft.com";
    var password = "password";
    
    using (ClientContext clientContext = new ClientContext(tenantAdminSiteUrl))
    {
    	SecureString securePassword = new SecureString();
    	foreach (char c in password.ToCharArray())
    	{
    		securePassword.AppendChar(c);
    	}
    
    	clientContext.AuthenticationMode = ClientAuthenticationMode.Default;
    	clientContext.Credentials = new SharePointOnlineCredentials(userName, securePassword);
    	
    	var tenant = new Tenant(clientContext);
        var siteProperties = tenant.GetSitePropertiesByUrl(siteCollectionUrl, true);
        tenant.Context.Load(siteProperties);
        tenant.Context.ExecuteQuery();
    	
    	siteProperties.DenyAddAndCustomizePages = DenyAddAndCustomizePagesStatus.Disabled;
        var operation = siteProperties.Update();
        tenant.Context.Load(operation, op => op.IsComplete, op => op.PollingInterval);
        tenant.Context.ExecuteQuery();
    	
    	// this is necessary, because the setting is not immediately reflected after ExecuteQuery
        while (!operation.IsComplete)
        {
            Thread.Sleep(operation.PollingInterval);
    		operation.RefreshLoad();
    		if (!operation.IsComplete)
    		{
    			try
    			{
    				tenant.Context.ExecuteQuery();
    			}
    			catch (WebException webEx)
    			{
    				// catch the error, something went wrong
    			}
    		}
        }
    }
