    bool ValidateEcdsa384JwtToken(string tokenString, ECDsa pubKey) 
    {
	    try
        {
            var securityToken = new JwtSecurityToken(tokenString);
            var securityTokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters() {
                ValidIssuer = securityToken.Issuer,
                ValidAudience = securityToken.Audiences.First(),
                IssuerSigningKey = new ECDsaSecurityKey(pubKey)
            };
            SecurityToken stoken;
            var claims = securityTokenHandler.ValidateToken(tokenString, validationParameters, out stoken);
            return true;
        }
        catch (System.Exception e)
        {
            return false;
        }
    }
