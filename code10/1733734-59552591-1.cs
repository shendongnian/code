    services.AddAuthentication().AddOpenIdConnect('oidc', options =>
                    {
        options.Events = new OpenIdConnectEvents
                        {
                            OnMessageReceived = OnMessageReceived,
                             OnRemoteFailure = context => {
                                 context.Response.Redirect("/");
                                 context.HandleResponse();
        
                                 return Task.FromResult(0);
                             }
        
                        };
    });
