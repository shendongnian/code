    services.AddAuthentication(sharedOptions =>
    {
        sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(jwtOptions=> {
        jwtOptions.IncludeErrorDetails = true;
        jwtOptions.Authority = "{Authority}";
        jwtOptions.Audience = "{Audience}";
        jwtOptions.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = "{ValidIssuer}",
            ValidAudience = "{ValidAudience}"
        };
        jwtOptions.Events = new JwtBearerEvents()
        {
            OnAuthenticationFailed = context => {
                //TODO:
                return Task.FromResult(0);
            },
            OnTokenValidated = context => {
                //At this point, the security token has been validated successfully and a ClaimsIdentity has been created
                var claimsIdentity = (ClaimsIdentity)context.Principal.Identity;
                //add your custom claims here
                claimsIdentity.AddClaim(new Claim("test", "helloworld!!!"));
                return Task.FromResult(0);
            }
        };
    })
    .AddAzureAd(options => Configuration.Bind("AzureAd", options))
    .AddCookie();
