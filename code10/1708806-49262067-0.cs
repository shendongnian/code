    public class HostAuthenticationFilterCustom : HostAuthenticationFilter
        {
            public HostAuthenticationFilterCustom(string authenticationType) : base(authenticationType)
            {
            }
            public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
            {
                return base.AuthenticateAsync(context,cancellationToken);
            }
            public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
            {
                return base.ChallengeAsync(context,cancellationToken);
            }
        }
