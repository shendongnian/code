    public List<string> ADUsers(string filter)
    {
        List<string> users = new List<string>();
    
        PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, "abc.in");
        UserPrincipal user = new UserPrincipal(domainContext)
        {
            GivenName = filter + "*"
        };
    
        PrincipalSearcher pS = new PrincipalSearcher
        {
            QueryFilter = user
        };
    
        PrincipalSearchResult<Principal> results = pS.FindAll();
        List<Principal> pc = results.ToList();
        foreach (Principal p in pc)
        {
            DirectoryEntry de = (DirectoryEntry)p.GetUnderlyingObject();
            if (de.Properties["givenName"].Value != null && de.Properties["sn"].Value != null)
                users.Add(de.Properties["givenName"].Value + " " + de.Properties["sn"].Value);
        }
    
        return users;
    }
