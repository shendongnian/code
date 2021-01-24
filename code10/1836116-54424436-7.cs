    services.AddAuthentication(options => {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie("Cookies")
                .AddOpenIdConnect(options =>
                {
                    options.ClientId = Configuration["Oidc:ClientId"];
                    options.ClientSecret = Configuration["Oidc:ClientSecret"];
                    options.Authority = Configuration["Oidc:Authority"];
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.ResponseType = Configuration["Oidc:ResponseType"];
                    options.Scope.Add("claims");
                    options.ClaimActions.Clear();
                    options.ClaimActions.MapUniqueJsonKey("roles", "roles");
                }
            );;
