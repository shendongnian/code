    private List<string> GetGroupMemberList(string strPropertyValue, string strActiveDirectoryHost, int intActiveDirectoryPageSize)
    {
        // Variable declaration(s).
        List<string> listGroupMemberDn = new List<string>();
        string strPath = strActiveDirectoryHost + "/<GUID=" + strPropertyValue + ">";
        const int intIncrement = 1500; // https://msdn.microsoft.com/en-us/library/windows/desktop/ms676302(v=vs.85).aspx
        var members = new List<string>();
        // The count result returns 350.
        var group = new DirectoryEntry(strPath, null, null, AuthenticationTypes.Secure);
        //var group = new DirectoryEntry($"LDAP://{"EnterYourDomainHere"}/<GUID={strPropertyValue}>", null, null, AuthenticationTypes.Secure);
        while (true)
        {
            var memberDns = group.Properties["member"];
            foreach (var member in memberDns)
            {
                members.Add(member.ToString());
            }
            if (memberDns.Count < intIncrement) break;
            group.RefreshCache(new[] { $"member;range={members.Count}-*" });
        }
        //Find users that have this group as a primary group
        var secId = new SecurityIdentifier(group.Properties["objectSid"][0] as byte[], 0);
        /* Find The RID (sure exists a best method)
         */
        var reg = new Regex(@"^S.*-(\d+)$");
        var match = reg.Match(secId.Value);
        var rid = match.Groups[1].Value;
        /* Directory Search for users that has a particular primary group
         */
        var dsLookForUsers =
            new DirectorySearcher(strActiveDirectoryHost) {
                Filter = string.Format("(primaryGroupID={0})", rid),
                SearchScope = SearchScope.Subtree,
                PageSize = 1000
        };
        dsLookForUsers.PropertiesToLoad.Add("distinguishedName");
        var srcUsers = dsLookForUsers.FindAll();
        foreach (SearchResult user in srcUsers)
        {
            members.Add(user.Properties["distinguishedName"][0].ToString());
        }
        return members;
    }
