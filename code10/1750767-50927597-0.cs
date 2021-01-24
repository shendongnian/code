    public class AzureADB2COpenIdConnectOptions : IConfigureNamedOptions<OpenIdConnectOptions>
    {
        public void Configure(string name, OpenIdConnectOptions options)
        {
            options.Events.OnAuthorizationCodeReceived = OnAuthorizationCodeReceived;
            options.Events.OnRedirectToIdentityProvider = OnRedirectToIdentityProvider;
        }
        public void Configure(OpenIdConnectOptions options)
        {
            options.Events.OnAuthorizationCodeReceived = OnAuthorizationCodeReceived;
            options.Events.OnRedirectToIdentityProvider = OnRedirectToIdentityProvider;
        }
        public async Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
        {
            var clientCredential = new ClientCredential(context.Options.ClientSecret);
            var userId = context.Principal.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userTokenCache = new MSALSessionCache(userId, context.HttpContext).GetMsalCacheInstance();
            var confidentialClientApplication = new ConfidentialClientApplication(
                context.Options.ClientId,
                context.Options.Authority,
                $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}",
                clientCredential,
                userTokenCache,
                null);
            try
            {
                var authenticationResult = await confidentialClientApplication.AcquireTokenByAuthorizationCodeAsync(
                    context.ProtocolMessage.Code,
                    new[]
                    {
                        "https://contoso.onmicrosoft.com/notes/read"
                    });
                context.HandleCodeRedemption(authenticationResult.AccessToken, authenticationResult.IdToken);
            }
            catch (Exception ex)
            {
                // TODO: Handle.
                throw;
            }
        }
        public Task OnRedirectToIdentityProvider(RedirectContext context)
        {
            context.ProtocolMessage.ResponseType = OpenIdConnectResponseType.CodeIdToken;
            context.ProtocolMessage.Scope += $" offline_access https://contoso.onmicrosoft.com/notes/read";
            return Task.FromResult(0);
        }
    }
