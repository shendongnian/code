            services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
                .AddAzureAD(options => Configuration.Bind("AzureAd", options));
            services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
            {
                options.Events = new OpenIdConnectEvents
                {
                    OnRedirectToIdentityProvider = async ctxt =>
                    {
                        // Invoked before redirecting to the identity provider to authenticate. This can be used to set ProtocolMessage.State
                        // that will be persisted through the authentication process. The ProtocolMessage can also be used to add or customize
                        // parameters sent to the identity provider.
                        await Task.Yield();
                    },
                    OnMessageReceived = async ctxt =>
                    {
                        // Invoked when a protocol message is first received.
                        await Task.Yield();
                    },
                    OnTicketReceived = async ctxt =>
                    {
                        // Invoked after the remote ticket has been received.
                        // Can be used to modify the Principal before it is passed to the Cookie scheme for sign-in.
                        // This example removes all 'groups' claims from the Principal (assuming the AAD app has been configured
                        // with "groupMembershipClaims": "SecurityGroup"). Group memberships can be checked here and turned into
                        // roles, to be persisted in the cookie.
                        if (ctxt.Principal.Identity is ClaimsIdentity identity)
                        {
                            ctxt.Principal.FindAll(x => x.Type == "groups")
                                .ToList()
                                .ForEach(identity.RemoveClaim);
                        }                        
                        await Task.Yield();
                    },
                };
            });
            services.Configure<CookieAuthenticationOptions>(AzureADDefaults.CookieScheme, options =>
            {
                options.Events = new CookieAuthenticationEvents
                {
                    // ...
                };
            });
