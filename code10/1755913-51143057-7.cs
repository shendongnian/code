    public class MySchemeHandler : IAuthenticationHandler
    {
        private HttpContext _context;
        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            _context = context;
            return Task.CompletedTask;
        }
        public Task<AuthenticateResult> AuthenticateAsync()
            => Task.FromResult(AuthenticateResult.NoResult());
        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            // do something
        }
        public Task ForbidAsync(AuthenticationProperties properties)
        {
            // do something
        }
    }
