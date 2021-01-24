    private static DirectoryEntry GetUserDEByDN(string sDN)
    {
        string adPath = ConfigurationManager.AppSettings["ADPath"].ToString();
        DirectoryEntry de = new DirectoryEntry(adPath + "/" + sDN);
        DirectoryEntry deManager = null;
        using (DirectorySearcher Search = new DirectorySearcher())
        {
            Search.SearchRoot = de;
            Search.Filter = "(&(distinguishedName=" + sDN + "))";
            //Search.Filter = "(objectClass = user)";
            Search.SearchScope = SearchScope.Base;
            SearchResult Result = Search.FindOne();
            if (null != Result)
                deManager = Result.GetDirectoryEntry();
        }
        return deManager;
    }
