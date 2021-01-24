    string jwtToken = null;
    AuthenticationHeaderValue authHeader = request.Headers.Authorization;
    if (authHeader != null)
    {
    	jwtToken = authHeader.Parameter;
    }
    if (jwtToken == null)
    {
    	HttpResponseMessage response = this.BuildResponseErrorMessage(HttpStatusCode.Unauthorized);
            return response;
    }
    
        .........
        .........
        .........
    
    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
    
    TokenValidationParameters validationParameters = new TokenValidationParameters
    {
    	// We accept both the App Id URI and the AppId of this service application
            ValidAudiences = new[] { audience, clientId },
        
    	// Supports both the Azure AD V1 and V2 endpoint
            ValidIssuers = new[] { issuer, $"{issuer}/v2.0" },
            IssuerSigningKeys = signingKeys
    };
        
    try
    {
    	// Validate token.
            SecurityToken validatedToken = new JwtSecurityToken();
            ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(jwtToken, validationParameters, out validatedToken);
