    public class MyCustomAuth : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public const string SchemeName = "MyCustom";
        public MyCustomAuth(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory 
            logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            if (Request.Host.Value == "")
            {
                await Context.ChallengeAsync(GoogleDefaults.AuthenticationScheme);
            }
            await Context.ChallengeAsync(FacebookDefaults.AuthenticationScheme);
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (Request.Host.Value == "")
            {
                return await Context.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            }
            return await Context.AuthenticateAsync(FacebookDefaults.AuthenticationScheme);
        }
    }
