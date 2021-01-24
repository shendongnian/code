     services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = $"https://{Configuration.GetValue<string>("AppServiceNameOutput")}",
                ValidAudience = $"https://{Configuration.GetValue<string>("AppServiceNameOutput")}",
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration.GetValue<string>("SigningKey"))),
            };
            options.Events = new JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    var tokenBlackList = context.HttpContext.RequestServices.GetRequiredService<ITokenBlackList>();
                    var tokenParser = context.HttpContext.RequestServices.GetRequiredService<ITokenParser>();
                    var bearer = context.HttpContext.Request.Headers["Authorization"];
                    if (String.IsNullOrEmpty(bearer))
                    {
                        bearer = context.Request.Query["access_token"];
                    }
                    var token = tokenParser.GetBearerTokenFromAuthHeaderString(bearer);
                    if (tokenBlackList.TokenIsBlackListed(token).Result)
                    {
                        context.Fail("Token has expired");
                    }
                    return Task.CompletedTask;
                }
            };
        });
