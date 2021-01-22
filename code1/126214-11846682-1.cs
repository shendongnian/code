    private static string[] GetGroupNames(string domainName, string userName)
    {
        List<string> result = new List<string>();
        using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domainName))
        {
            using (PrincipalSearchResult<Principal> src = UserPrincipal.FindByIdentity(principalContext, userName).GetGroups(principalContext))
            {
                src.ToList().ForEach(sr => result.Add(sr.SamAccountName));
            }
        }
        return result.ToArray();
    }
