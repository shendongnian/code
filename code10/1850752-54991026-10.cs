     PublicClientId = "self";
     OAuthOptions = new OAuthAuthorizationServerOptions
     {
        TokenEndpointPath = new PathString("/Token"),
          //Provider = new ApplicationOAuthProvider(PublicClientId),
         Provider = new CredentialsAuthorizationServerProvider(PublicClientId),
         AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
         AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
           // En el modo de producción establezca AllowInsecureHttp = false
         AllowInsecureHttp = true
     };
     // Permitir que la aplicación use tokens portadores para autenticar usuarios
     //app.UseOAuthBearerTokens(OAuthOptions);
     app.UseOAuthAuthorizationServer(OAuthOptions);
