    app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
                                               {
                                                   ClientId = clientId,
                                                   Authority = authority,
                                                   RedirectUri = redirectUri,
                                                   PostLogoutRedirectUri = redirectUri,
                                                   Scope = "openid profile",
                                                   ResponseType = "id_token",
                                                   TokenValidationParameters = new TokenValidationParameters { ValidateIssuer = false, NameClaimType = "name" },
                                                   Notifications = new OpenIdConnectAuthenticationNotifications
                                                                   {
                                                                       AuthenticationFailed = this.OnAuthenticationFailedAsync,
                                                                       SecurityTokenValidated = this.OnSecurityTokenValidatedAsync
                                                                   }
                                               });
    ConfidentialClientApplication daemonClient = new ConfidentialClientApplication(Startup.clientId, string.Format(AuthorityFormat, tenantId), Startup.redirectUri,
                                                                                           new ClientCredential(Startup.clientSecret), null, appTokenCache.GetMsalCacheInstance());
    AuthenticationResult authResult = await daemonClient.AcquireTokenForClientAsync(new[] { MSGraphScope });
