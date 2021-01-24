    public class ClientTokenHandler : AuthenticationHandler<ClientTokenOptions>
    {
        private readonly string[] _clientTokens;
        public ClientTokenHandler(IOptionsMonitor<ClientTokenOptions> optionsMonitor,
            ILoggerFactory loggerFactory, UrlEncoder urlEncoder, ISystemClock systemClock,
            IConfiguration config)
            : base(optionsMonitor, loggerFactory, urlEncoder, systemClock)
        {
            _clientTokens = config.GetSection("ClientTokens").Get<string[]>();
        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var tokenHeaderValue = (string)Request.Headers["X-TOKEN"];
            if (string.IsNullOrWhiteSpace(tokenHeaderValue))
                return Task.FromResult(AuthenticateResult.NoResult());
            if (!_clientTokens.Contains(tokenHeaderValue))
                return Task.FromResult(AuthenticateResult.Fail("Unknown Client"));
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(
                Enumerable.Empty<Claim>(),
                Scheme.Name));
            var authenticationTicket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(authenticationTicket));
        }
    }
