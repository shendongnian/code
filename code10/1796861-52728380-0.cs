    public void ConfigureServices(IServiceCollection services)
    {
        // …
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                // …
                options.Events.OnTicketReceived = OnOpenIdConnectTicketReceived;
            });
    }
    public static Task OnOpenIdConnectTicketReceived(TicketReceivedContext context)
    {
        if (context.Principal.Identity is ClaimsIdentity identity)
        {
            identity.AddClaim(new Claim("foo", "bar"));
        }
        return Task.CompletedTask;
    }
