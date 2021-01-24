    public class AzureADB2COpenIdConnectOptionsConfigurator : IConfigureNamedOptions<OpenIdConnectOptions>
    {
        private readonly AzureADB2CWithApiOptions _options;
        public AzureADB2COpenIdConnectOptionsConfigurator(IOptions<AzureADB2CWithApiOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }
        public void Configure(string name, OpenIdConnectOptions options)
        {
            options.Events.OnAuthorizationCodeReceived = WrapOpenIdConnectEvent(options.Events.OnAuthorizationCodeReceived, OnAuthorizationCodeReceived);
            options.Events.OnRedirectToIdentityProvider = WrapOpenIdConnectEvent(options.Events.OnRedirectToIdentityProvider, OnRedirectToIdentityProvider);
        }
        public void Configure(OpenIdConnectOptions options)
        {
            Configure(Options.DefaultName, options);
        }
        private static Func<TContext, Task> WrapOpenIdConnectEvent<TContext>(Func<TContext, Task> baseEventHandler, Func<TContext, Task> thisEventHandler)
        {
            return new Func<TContext, Task>(async context =>
            {
                await baseEventHandler(context);
                await thisEventHandler(context);
            });
        }
        private async Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
        {
            var clientCredential = new ClientCredential(context.Options.ClientSecret);
            var userId = context.Principal.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userTokenCache = new SessionTokenCache(context.HttpContext, userId);
            var confidentialClientApplication = new ConfidentialClientApplication(
                context.Options.ClientId,
                context.Options.Authority,
                $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}",
                clientCredential,
                userTokenCache.GetInstance(),
                null);
            try
            {
                var authenticationResult = await confidentialClientApplication.AcquireTokenByAuthorizationCodeAsync(
                    context.ProtocolMessage.Code, _options.ApiScopes.Split(' '));
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
            context.ProtocolMessage.Scope += $" offline_access {_options.ApiScopes}";
            return Task.FromResult(0);
        }
    }
