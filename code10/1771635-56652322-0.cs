     services.AddAuthentication()
               .AddOpenIdConnect(GoogleDefaults.AuthenticationScheme,
                   GoogleDefaults.DisplayName,
                   options =>
                   {
                       options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                       options.Authority =  "https://accounts.google.com";
                       options.ClientId = googleOAuthSettings.ClientId;
                       options.ClientSecret = googleOAuthSettings.ClientSecret;
                       options.ResponseType = OpenIdConnectResponseType.IdToken;
                       options.CallbackPath =  "signin-google";
                       options.SaveTokens = true; //this has to be true to get the token value
                       options.Scope.Add("email");
                   });
