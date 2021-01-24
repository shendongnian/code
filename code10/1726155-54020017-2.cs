    		app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions()
	    {
		    Notifications = new OpenIdConnectAuthenticationNotifications()
    		{
	    		AuthenticationFailed = AuthenticationFailedNotification<OpenIdConnect.OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> authFailed =>
			    {
				    if (authFailed.Exception.Message.Contains("IDX21323"))
				    {
					    authFailed.HandleResponse();
					    authFailed.OwinContext.Authentication.Challenge();
				    }
				    await Task.FromResult(true);
			    }
		    }
	    });
