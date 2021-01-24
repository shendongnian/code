    public TokenValidationParameters CreateTokenValidationParameters()
    {
        var result = new TokenValidationParameters
        {
        ValidateIssuer = false,
        ValidIssuer = ValidIssuer,
        ValidateAudience = false,
        ValidAudience = ValidAudience,
        ValidateIssuerSigningKey = false,
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey)),
        //comment this and add this line to fool the validation logic
        SignatureValidator = delegate(string token, TokenValidationParameters parameters)
        {
            var jwt = new JwtSecurityToken(token);
            return jwt;
        },
        RequireExpirationTime = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        };
        result.RequireSignedTokens = false;
        return result;
    }
