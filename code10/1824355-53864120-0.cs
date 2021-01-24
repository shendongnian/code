        services.AddAuthentication(sharedOptions =>
                {
                    sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    sharedOptions.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    sharedOptions.DefaultChallengeScheme = WsFederationDefaults.AuthenticationScheme;
                })
                .AddWsFederation(options =>
                {
                    //rest configuration
                    options.Events.OnSecurityTokenValidated = context => {
                        var token = context.ProtocolMessage.GetToken();
                        var identity = new ClaimsIdentity();
                        identity.AddClaim(new Claim("token", token));
                        context.Principal.AddIdentity(identity);
                        return Task.CompletedTask;
                    };
                })
                .AddCookie();
