    using System.DirectoryServices.AccountManagement;
    private bool CheckUserinAD(string domain, string username)
    {
        PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, domain);
        UserPrincipal user = new UserPrincipal(domainContext);
        user.Name = username;
        PrincipalSearcher pS = new PrincipalSearcher();
        pS.QueryFilter = user;
        PrincipalSearchResult<Principal> results = pS.FindAll();
        if (results != null && results.Count() > 0)
            return true;
        return false;
    }
