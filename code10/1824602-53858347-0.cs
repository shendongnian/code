    using System.DirectoryServices.AccountManagement;
    
    // ...
    
    public List<string> GetGroupsForUser(string domain, string ou, string samAccountName)
    {
        var groups = new List<string>(); 
    
        using (var principalContext = new PrincipalContext(ContextType.Domain, domain, ou))
        using (var userPrinicpal = UserPrincipal.FindByIdentity(principalContext, 
            IdentityType.SamAccountName, samAccountName))
        {
            if (userPrinicpal == null)
                return null;
                
            foreach (var securityGroup in userPrinicpal.GetAuthorizationGroups())
                groups.Add(securityGroup.DisplayName);
        }
        
        return groups;
    }
