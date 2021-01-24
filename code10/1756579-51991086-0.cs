    public void ConfigureServices(IServiceCollection services)
            {
                services.AddAuthentication(options =>
                    {
                        //Auth schemes here
                    })
                    .AddOpenIdConnect(oid =>
                    {
                        //Other config here
                        oid.Events = new OpenIdConnectEvents()
                        {
                            OnRemoteFailure = OnRemoteFailure
    
                        };
                    });
            }
    private Task OnRemoteFailure(RemoteFailureContext context)
            {
                
                if (context.Failure.Message.Contains("Correlation failed"))
                {
                    context.Response.Redirect("/AppName"); // redirect without trailing slash
                    context.HandleResponse();
                }
    
                return Task.CompletedTask;
            }
