    new TokenValidationParameters
                    {
                        IssuerSigningKey = signingKey,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        ValidateLifetime = true,
    
                        ClockSkew = TimeSpan.Zero
                    };
