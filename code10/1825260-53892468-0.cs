    public Task InvokeAsync(HttpContext context)
    {
        var accessToken = context.Request.Headers["Authorization"];
        
        var secretKey = "Insert your secret key here";
        var validationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true;
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
            // Add any other validations: issuer, audience, lifetime, etc
        }
        var handler = new JwtSecurityTokenHandler();
        ClaimsPrincipal principal;
        try
        {
            principal = handler.ValidateToken(accessToken, validationParameters, out SecurityToken validToken);
            JwtSecurityToken validJwt = validToken as JwtSecurityToken;
            
            if (validJwt == null)
                throw new ArgumentException("Invalid JWT");
            if (!validJwt.Header.Alg.Equals(SecurityAlgorithms.RsaSha256Signature, StringComparison.Ordinal))
                throw new ArgumentException("Algorithm must be RS256");
            // Add any validations which cannot be included into TokenValidationParameters
        }
        // Validation passed, continue with your logic
    }
