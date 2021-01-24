    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKeys = new[] { new SymmetricSecurityKey(key) },
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });
