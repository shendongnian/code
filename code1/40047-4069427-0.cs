    public static bool ValidateCredentials(string username, string password)
    {
        using (PrincipalContext principalContext = new PrincipalContext(ContextType.Machine))
        {
        	return principalContext.ValidateCredentials(username, password);
        }
    }
    
    public static bool validateAdminCredentials(string username, string password)
    {
        using (PrincipalContext principalContext = new PrincipalContext(ContextType.Machine))
        {
            if (principalContext.ValidateCredentials(username, password))
            {
                using (UserPrincipal user = UserPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, username))
                using (GroupPrincipal group = GroupPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, "Administrators"))
                {
                    if (null != group && user.IsMemberOf(group))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
