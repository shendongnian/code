    public class JwtAuthenticationFilter : IAuthenticationFilter
    {
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var token = GetTokenFromAuthorizeHeader(context.Request);
            if (TokenIsValid(token)) {
                var principal = CreatePrincipal(token);
                // Use context.Principal instead of Thread.CurrentPrincipal
                // and HttpContext.Current.User whenever.
                context.Principal = principal;
            }
            return Task.CompletedTask;
        }
        // TODO: Implement remaining IAuthencitaionFilter members.
    }
