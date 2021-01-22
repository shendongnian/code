    using (var domainContext = new PrincipalContext(ContextType.Domain, domainName))
    {
	    using (var foundUser = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, username)) 
	    {
		    if (foundUser.Enabled.HasValue) 
		    {
			    return (bool)foundUser.Enabled;
		    }
            else
            {
                return true; //or false depending what result you want in the case of Enabled being NULL
            }
	    }
    }
