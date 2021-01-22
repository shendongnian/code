    public bool UserInDomain(string username, string domain)
    {
        string LDAPString = string.Empty;
        string[] domainComponents = domain.Split('.');
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < domainComponents.Length; i++)
        {
            builder.AppendFormat(",dc={0}", domainComponents[i]);
        }
        if (builder.Length > 0)
            LDAPString = builder.ToString(1, builder.Length - 1);
        DirectoryEntry entry = new DirectoryEntry("LDAP://" + LDAPString);
        DirectorySearcher searcher = new DirectorySearcher(entry);
        searcher.Filter = "sAMAccountName=" + username;
        SearchResult result = searcher.FindOne();
        return result != null;
    }
