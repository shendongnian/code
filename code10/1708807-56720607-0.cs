`
public class HostAuthenticationFilterCustom : HostAuthenticationFilter, IAuthenticationFilter
    {
        public HostAuthenticationFilterCustom(string authenticationType) : base(authenticationType)
        {
        }
        public new Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            return base.AuthenticateAsync(context,cancellationToken);
        }
        public new Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return base.ChallengeAsync(context,cancellationToken);
        }
    }
`
