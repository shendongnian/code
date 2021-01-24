    var tokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = false,
                    //ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],
    
                    ValidateAudience = false,
                    //ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],
    
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = _signingKey,
    
                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
