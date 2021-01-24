    ...
    ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
                   OAuthDefaults.AuthenticationType);
    
    oAuthIdentity.AddClaim(new Claim("UserId", user.Id));   //<= The UserId add here as claim
    oAuthIdentity.AddClaim(new Claim("UserName", user.UserName));  //<= The UserName add here as claim
    
    ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                    CookieAuthenticationDefaults.AuthenticationType);
    ...
    
