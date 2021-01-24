    public class OurOwnAuthenticationHandler : AuthenticationHandler<ApiKeyAuthOpts>
    {
        public OurOwnAuthenticationHandler(IOptionsMonitor<ApiKeyAuthOpts> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {
        }
    
       
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            StringValues authorizationHeaders;
            if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out authorizationHeaders))
                 return AuthenticateResult.NoResult();
            // ... return AuthenticateResult.Fail(exceptionMessage);
            // ... return AuthenticateResult.Success(ticket)
        } 
    
        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.StatusCode = 401;
            var message = "tell me your token";
            Response.Body.Write(Encoding.UTF8.GetBytes(message));
            return Task.CompletedTask;
        }
        protected override Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            Response.StatusCode = 403;
            var message = "you have no rights";
            Response.Body.Write(Encoding.UTF8.GetBytes(message));
            return Task.CompletedTask;
        }
    
    }
