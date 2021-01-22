    public ArrayList getGroups()
    {
        // ACTIVE DIRECTORY AUTHENTICATION DATA
        string ADDomain = "myDomain.local";
        string ADBranchsOU = "Distribution Group";
        string ADUser = "Admin";
        string ADPassword = "password";
        // CREATE ACTIVE DIRECTORY ENTRY 
        DirectoryEntry ADRoot 
            = new DirectoryEntry("LDAP://OU=" + ADBranchsOU
                                 + "," + getADDomainDCs(ADDomain),
                                 ADUser, 
                                 ADPassword);
        // CREATE ACTIVE DIRECTORY SEARCHER
        DirectorySearcher searcher = new DirectorySearcher(ADRoot);
        searcher.Filter = "(&(objectClass=group)(cn=* Region))";
        SearchResultCollection searchResults = searcher.FindAll();
        // ADDING ACTIVE DIRECTORY GROUPS TO LIST
        ArrayList list = new ArrayList();
        foreach (SearchResult result in searchResults)
        {
            string groupName = result.GetDirectoryEntry().Name.Trim().Substring(3);
            list.Add(groupName);
        }
        return list; 
    }
    public string getADDomainDCs(string ADDomain)
    {
        return (!String.IsNullOrEmpty(ADDomain)) 
            ? "DC=" + ADDomain.Replace(".", ",DC=") 
            : ADDomain;
    }
