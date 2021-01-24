        public class CustomCookieAuthenticationHandler : CookieAuthenticationHandler
    {
        public CustomCookieAuthenticationHandler(IOptionsMonitor<CookieAuthenticationOptions> options
            , ILoggerFactory logger
            , UrlEncoder encoder
            , ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
        protected override Task HandleSignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
        {
            if (user.Identity.Name == "test@outlook.com")
            {
                properties.ExpiresUtc = Clock.UtcNow.AddMinutes(15);
            }
            else
            {
                properties.ExpiresUtc = Clock.UtcNow.AddMinutes(35);
            }
            return base.HandleSignInAsync(user, properties);
        }
    }
