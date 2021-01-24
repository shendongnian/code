    DirectoryEntry startingPoint = new DirectoryEntry("LDAP://DC=Zone,DC=Corp,DC=COM", "UserName", "Password");
    DirectorySearcher searcher = new DirectorySearcher(startingPoint)
        {
            SearchScope = SearchScope.Subtree,
            Filter = $"(&(objectCategory=Computer)(cn={hostname}))"
        };
    SearchResult result = searcher.FindOne();
