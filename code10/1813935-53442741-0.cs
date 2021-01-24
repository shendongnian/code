    public Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
    	var subjectId = context.Subject.GetSubjectId();
    	Guid.TryParse(subjectId, out Guid g);
    
        //whatever way or wherever you retrieve the claims from
    	var claimsForUser = idRepo.GetUserClaimsBySubjectId(g);
    
    	context.IssuedClaims = claimsForUser.Select(c => 
            new Claim(c.ClaimType, c.ClaimValue)).ToList();
    
    	return Task.FromResult(0);
    }
