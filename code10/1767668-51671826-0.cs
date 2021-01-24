    private static List<DirectoryEntry> GetUserDEByManagerDN(string sManagerDN)
    {
        string adPath = ConfigurationManager.AppSettings["ADPath"].ToString();
        
        /* This was one of the issues  */
        //DirectoryEntry de = new DirectoryEntry(adPath + "/" + sManagerDN);
        DirectoryEntry de = new DirectoryEntry(adPath);
        List<DirectoryEntry> lsUsers = new List<DirectoryEntry>();
        using (DirectorySearcher Search = new DirectorySearcher())
        {
            Search.SearchRoot = de;
            /* I had to include extension attribute 14 to get rid of some unusual "users", like Fax, special accounts, etc. You might not need it
            //Search.Filter = "(manager=" + sDN + ")";
            Search.Filter = "(&(manager=" + sDN + ")(extensionAttribute14=INV))";
            //Search.SearchScope = SearchScope.Base;  
            Search.SearchScope = SearchScope.Subtree;
            SearchResultCollection Results = Search.FindAll();
            if (null != Results)
            {
                foreach (SearchResult Result in Results)
                {
                    DirectoryEntry deUser = Result.GetDirectoryEntry();
                    if (null != deUser)
                        lsUsers.Add(deUser);
                }
            }
        }
        return lsUsers;
    }
