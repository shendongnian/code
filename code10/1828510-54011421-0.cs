    public class CustomAuthenticationHandler : AuthenticationHandler<CustomAuthHandlerOptions>
    {
        public CustomAuthenticationHandler(IOptionsMonitor<CustomAuthHandlerOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //Write custom logic here
            return await Context.AuthenticateAsync(Scheme.Name);
        }
    }
    public class CustomAuthHandlerOptions : AuthenticationSchemeOptions
    {
        public string MyCustomOptionsProp { get; set; }
    }
