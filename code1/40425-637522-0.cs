    using(DirectoryEntry de = new DirectoryEntry("LDAP://MyDomainController"))
    {
       using(DirectorySearcher adSearch = new DirectorySearcher(de))
       {
         adSearch.Filter = "(sAMAccountName=someuser)";
         SearchResult adSearchResult = adSearch.FindOne();
       }
    }
