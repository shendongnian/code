    var accessToken = await HttpContext.GetTokenAsync("access_token");
    var tokenHandler = new JwtSecurityTokenHandler();
    var jwtSecurityToken = tokenHandler.ReadJwtToken(accessToken);
    // Depending on the lifetime of the access token.
    // This is just an example. An access token may be valid
    // for less than one minute.
    if (jwtSecurityToken.ValidTo < DateTime.UtcNow.AddMinutes(5))
    {
        var responseToken = await RenewTokensAsync();
        if (responseToken == null)
        {
            throw new Exception("Error");
        }
        accessToken = responseToken.AccessToken;
    }
    // Proceed, accessToken contains a valid token.
