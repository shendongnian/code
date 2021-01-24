    public class MySchemeHandler : IAuthenticationHandler
    {
        private HttpContext _context;
        Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            _context = context;
        }
        Task<AuthenticateResult> AuthenticateAsync()
            => Task.FromResult(AuthenticateResult.NoResult());
        Task ChallengeAsync(AuthenticationProperties properties)
        {
            // do something
        }
        Task ForbidAsync(AuthenticationProperties properties)
        {
            // do something
        }
    }
