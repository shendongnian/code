    public void ConfigureServices(IServiceCollection Services)
    {
        // Require authentication token.
        // Enable CompanyName token for SharePoint workflow client, which cannot pass HTTP headers > 255 characters (JWT tokens are > 255 characters).
        // Enable JWT token for all other clients.  The JWT token specifies the security algorithm used when it was signed (by Identity service).
        Services.AddAuthentication(AuthenticationHandler.AuthenticationScheme).AddCompanyNameAuthentication(Options =>
        {
            Options.Identities = Program.AppSettings.AuthenticationIdentities;
            Options.ForwardDefaultSelector = HttpContext =>
            {
                // Forward to JWT authentication if CompanyName token is not present.
                string token = string.Empty;
                if (HttpContext.Request.Headers.TryGetValue(AuthenticationHandler.HttpHeaderName, out StringValues authorizationValues))
                {
                    token = authorizationValues.ToString();
                }
                return token.StartsWith(AuthenticationHandler.TokenPrefix)
                    ? AuthenticationHandler.AuthenticationScheme
                    : JwtBearerDefaults.AuthenticationScheme;
            };
        })
        .AddJwtBearer(Options =>
        {
            Options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Program.AppSettings.ServiceOptions.TokenSecret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(_clockSkewMinutes)
            };
        });
