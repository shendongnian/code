    public bool CheckUserInOU(string userName)
    {
        using (var entryPoint = new DirectoryEntry($@"LDAP://onecity/OU=bar,OU=foo,DC=onecity,DC=corp,DC=fabrikam,DC=com"))
        {
            // User and pass for the LDAP query user if needed.
            entryPoint.Username = "YourUsernameHere";
            entryPoint.Password = "YourPasswordHere";
            using (var searcher = new DirectorySearcher(entryPoint))
            {
                searcher.SearchScope = SearchScope.OneLevel;
                searcher.Filter = $"(&(samAccountName={userName})(objectCategory=user))";
                return searcher.FindOne() != null;
            }
        }
    }
