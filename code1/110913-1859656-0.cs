    string[] UserGroups(string domain, string domainUserName)
    {
        WindowsIdentity ident = new WindowsIdentity(domainUserName + "@" + domain);
        List<string> groups = new List<string>();
        foreach (IdentityReference g in ident.Groups)
        {            
            groups.Add(g.Value);
        }
        return groups.ToArray();
    }
    string[] AllowedAccounts(string filePath)
    {
        List<string> accounts = new List<string>();
        FileInfo fInfo = new FileInfo(filePath);
        var fsec = fInfo.GetAccessControl();
        AuthorizationRuleCollection acl = fsec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
        foreach (FileSystemAccessRule ace in acl)
        {
            accounts.Add(ace.IdentityReference.Value);
        }
        return accounts.ToArray();
    }
