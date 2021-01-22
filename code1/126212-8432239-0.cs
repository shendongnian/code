    private static string[] GetGroupNames(string userName)
    {
        List<string> result = new List<string>();
        using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "YOURDOMAIN"))
        {
            using (PrincipalSearchResult<Principal> src = UserPrincipal.FindByIdentity(pc, userName).GetGroups(pc))
            {
                src.ToList().ForEach(sr => result.Add(sr.SamAccountName));
            }
        }
        return result.ToArray();
    }
