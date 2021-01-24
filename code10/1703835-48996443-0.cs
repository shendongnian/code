    public class TokenAuthenticationOptions : AuthenticationSchemeOptions
    {
    }
    public class TokenAuthentication : AuthenticationHandler<TokenAuthenticationOptions>
    {
        public const string SchemeName = "TokenAuth";
        public TokenAuthentication(IOptionsMonitor<TokenAuthenticationOptions> options, ILoggerFactory logger, 
                                    UrlEncoder encoder, ISystemClock clock) 
                                        : base(options, logger, encoder, clock)
        {
        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return Task.Run(() => Authenticate());
        }
        private AuthenticateResult Authenticate()
        {
            string auth, token;
            auth = Context.Request.Headers["Authorization"];
            if (auth == null) return AuthenticateResult.Fail("No JWT token provided");
            var auths = auth.Split(" ");
            if (auths[0].ToLower() != "bearer") return AuthenticateResult.Fail("Invalid authentication");
            token = auths[1];
            try
            {
                var generator = new TokenGenerator();
                var principal = generator.Validate(token);
                return AuthenticateResult.Success(new AuthenticationTicket(principal, SchemeName));
            }
            catch
            {
                return AuthenticateResult.Fail("Failed to validate token");
            }
        }
    }
