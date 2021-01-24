    .AddJwtBearer("<authenticationScheme>", configureOptions =>
    {
       options.TokenValidationParameters.ValidateActor = false;
       options.TokenValidationParameters.ValidateAudience = false;
       options.TokenValidationParameters.ValidateIssuerSigningKey = false;
       ...
    }
