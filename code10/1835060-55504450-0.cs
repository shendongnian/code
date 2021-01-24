    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.IdentityModel.Protocols.OpenIdConnect;
    ...
    var openidOptions = new OpenIdConnectOptions(authenticationScheme)
    {
        ClientSecret = secret,
        AutomaticAuthenticate = true,
        SignInScheme = "Identity.External",
        Authority = identityServerAddress,
        ClientId = clientId,
        RequireHttpsMetadata = true,
        ResponseType = OpenIdConnectResponseType.CodeIdToken,
        AutomaticChallenge= true,
        GetClaimsFromUserInfoEndpoint = true,
        SaveTokens = true,
        Events = new OpenIdConnectEvents
        {
            OnRemoteSignOut = async remoteSignOutContext =>
            {
                remoteSignOutContext.HttpContext.Session.Clear();
            },
        },
    };
    openidOptions.Scope.Clear();
    openidOptions.Scope.Add("openid");
    app.UseOpenIdConnectAuthentication(openidOptions);
