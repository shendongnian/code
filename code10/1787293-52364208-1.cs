    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
    {
        var userId = user.Id;
        user = await UserManager.Users.SingleAsync(u => u.Id == userId);
    
        // Add role claims
        var identity = await base.GenerateClaimsAsync(user);
    
        // Add custom claims for application user properties we want to store in claims (in cookies) which allows to get common values on UI without DB hit)
        identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName ?? ""));
        identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName ?? ""));
    
        // Add your session or any other claims here if needed
    
        return identity;
    }
