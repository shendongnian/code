    private bool IsValid(string token, string issuer, string configId)
    {
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = jwtSecurityTokenHandler.ReadToken(token) as JwtSecurityToken;
        // Extract the kid from token header
        var kidHeader = jwtSecurityToken.Header.Where(k => k.Key.ToLower() == "kid")?.FirstOrDefault();
        if (kidHeader?.Value == null) ThrowInvalidOperation($"Failed to find matching kid for Issuer: {issuer.ToLower() }");
        var kid = kidHeader?.Value as string;
        // Extract the expiration time from token payload
        var expirationTime = jwtSecurityToken.Payload?.Exp;
        if (expirationTime == null) ThrowInvalidOperation($"Failed to find matching expiration time for Issuer: {issuer.ToLower() }");
        // Decode to verify signature
        var verifiedToken = JWT.Decode(token, GetPublicKey(kid, issuer, providerId));
        if (verifiedToken != null)
        {
            var json = JsonConvert.DeserializeObject<dynamic>(verifiedToken);
            return IsValidIssuer(json, issuer) && IsValidExpirationTime(json, expirationTime);
        }
        else
        {
            return false;
        }
        void ThrowInvalidOperation(string msg) => throw new InvalidOperationException(msg);
    }
    private bool IsValidIssuer(dynamic json, string issuer)
    {
        if (json != null && issuer != null)
        {
            if (json["iss"] == issuer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    private bool IsValidExpirationTime(dynamic json, int? expTime)
    {
        if (json != null && expTime != null)
        {
            if (json["exp"] == expTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    private RSA GetPublicKey(string kid, string validIssuer, string configId)
    {
        var openIdConfig = openIdConfigurationProvider.GetOpenIdConfiguration(configId);
        var matchingKid = openIdConfig?.JsonWebKeySet?.Keys?.FirstOrDefault(x => x.Kid == kid);
        if (matchingKid == null)
        {
            throw new InvalidOperationException($"kid is null");
        }
        var rsa = RSA.Create();
        rsa.ImportParameters(new RSAParameters
        {
            Exponent = Base64UrlEncoder.DecodeBytes(matchingKid.E),
            Modulus = Base64UrlEncoder.DecodeBytes(matchingKid.N),
        });
        return rsa;
    }
