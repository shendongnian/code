    public class CustomAuthHandler : AuthenticationHandler<CustomAuthOptions>
    {
        private readonly HttpClient _httpclient;
        public LocalAccessTokenValidationHandler(IOptionsMonitor<LocalAccessTokenValidationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock,  HttpClient httpclient)
            : base(options, logger, encoder, clock)
        {
            _httpclient= httpclient;
        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // use _httpclient here and authenticate request and return AuthenticateResult
        }
