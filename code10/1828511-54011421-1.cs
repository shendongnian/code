            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                })
                .AddScheme<CustomAuthHandlerOptions, CustomAuthenticationHandler>("CustomAuthJwt", options =>
                    {
                        options.MyCustomOptionsProp = "Custom Value";
                    });
