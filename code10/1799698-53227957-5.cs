    using System.Security.Claims;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.Primitives;
    
    
    namespace CompanyName.Core2.Application.Middleware
    {
        [UsedImplicitly]
        public class AuthenticationHandler : AuthenticationHandler<AuthenticationOptions>
        {
            public const string AuthenticationScheme = "CompanyName Token";
            [UsedImplicitly] public const string HttpHeaderName = "Authorization";
            [UsedImplicitly] public const string TokenPrefix = "CompanyName ";
    
    
            public AuthenticationHandler(IOptionsMonitor<AuthenticationOptions> Options, ILoggerFactory Logger, UrlEncoder Encoder, ISystemClock Clock)
                : base(Options, Logger, Encoder, Clock)
            {
            }
    
    
            protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
            {
                if (!Request.Headers.TryGetValue(HttpHeaderName, out StringValues authorizationValues))
                {
                    // Indicate failure.
                    return await Task.FromResult(AuthenticateResult.Fail($"{HttpHeaderName} header not found."));
                }
                string token = authorizationValues.ToString();
                foreach (AuthenticationIdentity authenticationIdentity in Options.Identities)
                {
                    if (token == $"{TokenPrefix}{authenticationIdentity.Token}")
                    {
                        // Authorization token is valid.
                        // Create claims identity, add roles, and add claims.
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(AuthenticationScheme);
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, authenticationIdentity.Username));
                        foreach (string role in authenticationIdentity.Roles)
                        {
                            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
                        }
                        foreach (string claimType in authenticationIdentity.Claims.Keys)
                        {
                            string claimValue = authenticationIdentity.Claims[claimType];
                            claimsIdentity.AddClaim(new Claim(claimType, claimValue));
                        }
                        // Create authentication ticket and indicate success.
                        AuthenticationTicket authenticationTicket = new AuthenticationTicket(new ClaimsPrincipal(claimsIdentity), Scheme.Name);
                        return await Task.FromResult(AuthenticateResult.Success(authenticationTicket));
                    }
                }
                // Indicate failure.
                return await Task.FromResult(AuthenticateResult.Fail($"Invalid {HttpHeaderName} header."));
            }
        }
    }
