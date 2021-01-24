    SecurityTokenValidated = notification =>
    {
    	ClaimsIdentity identity = notification.AuthenticationTicket.Identity;
    	string[] roles = { "Role1", "Role2" };
    	foreach (var role in roles)
    	{
    		identity.AddClaim(new Claim(ClaimTypes.Role, role));
    	}
    	return Task.FromResult(0);
    }
 
