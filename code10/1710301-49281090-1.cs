    var tokenClient = new TokenClient(
						  IdentityServerTokenEndpoint,
						  "clientId",
						  "clientSecret");
	var tokenResponse = await tokenClient.RequestAuthorizationCodeAsync(
							n.Code, n.RedirectUri);
	if (tokenResponse.IsError)
	{
		throw new Exception(tokenResponse.Error);
	}
	// create new identity
	var id = new ClaimsIdentity(n.AuthenticationTicket.Identity.AuthenticationType);
	id.AddClaim(new Claim("access_token", tokenResponse.AccessToken));
	id.AddClaim(new Claim("expires_at", DateTime.Now.AddSeconds(tokenResponse.ExpiresIn).ToLocalTime().ToString()));
	id.AddClaim(new Claim("refresh_token", tokenResponse.RefreshToken));
	id.AddClaim(new Claim("id_token", n.ProtocolMessage.IdToken));
	id.AddClaims(n.AuthenticationTicket.Identity.Claims);
	// get user info claims and add them to the identity
	var userInfoClient = new UserInfoClient(IdentityServerUserInfoEndpoint);
	var userInfoResponse = await userInfoClient.GetAsync(tokenResponse.AccessToken);
	var userInfoEndpointClaims = userInfoResponse.Claims;
    
    // this line prevents claims duplication and also depends on the IdentityModel library version. It is a bit different for >v2.0
	id.AddClaims(userInfoEndpointClaims.Where(c => id.Claims.Any(idc => idc.Type == c.Type && idc.Value == c.Value) == false));
    // create the authentication ticket
	n.AuthenticationTicket = new AuthenticationTicket(
							new ClaimsIdentity(id.Claims, n.AuthenticationTicket.Identity.AuthenticationType, "name", "role"),
							n.AuthenticationTicket.Properties);
