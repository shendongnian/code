    services.AddAuthentication()
        .AddOpenIdConnect(opts =>
        {
            opts.Events = new OpenIdConnectEvents
	    {
	        OnAuthorizationCodeReceived = ctx =>
	        {
	            return Task.CompletedTask;
	        }
	    };
        });
