    if (user.Functions.Any())
    {
      var joinedFunctions = string.Join(";", user.Functions);
      identity.AddClaim(CustomClaimTypes.Functions, joinedFunctions, OpenIdConnectConstants.Destinations.IdentityToken);
    }
