    public IEnumerable<string> ComputerList()
    {
        DirectoryEntry rootDSE = new DirectoryEntry("LDAP://MyDomain.Local");
    
        DirectorySearcher computerSercher = new DirectorySearcher(rootDSE)
        {
            PageSize = 1000,
            Filter = "(&(objectClass=computer))"
        };
        computerSercher.PropertiesToLoad.Add("cn");
        
        using (var results = computerSercher.FindAll())
        {
            foreach (SearchResult result in results)
            {
                yield return (string) result.Properties["cn"][0];
            }
        }
    }
