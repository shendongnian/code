    string userName = "Jo Bloggs";
    string baseQuery =
        "(&" +
            "(objectCategory=person)" +
            "(objectClass=user)" +
            "(|" +
                "(&" +
                    "(sn={0}*)" +
                    "(givenName={1}*)" +
                ")" +
                "(displayName={2})" +
            ")" +
        ")"; // <<< this is missing in your original query
    userName = Regex.Replace(userName, @"[\(\)\*\\]", (match) =>
                    {   // escape reserved chars
                        return "\\" + ((int)match.Value[0]).ToString("x");
                    }, RegexOptions.Compiled);
    string query = String.Format(query, userName.Split(' ')[1], 
                                        userName.Split(' ')[0], userName);
    using (DirectoryEntry entry = new DirectoryEntry(
        "LDAP://" + Environment.UserDomainName, "user", "password",
        AuthenticationTypes.Secure))
    {
        using (DirectorySearcher ds = 
           new DirectorySearcher(entry, query, null, SearchScope.Subtree))
        {
            SearchResultCollection res = ds.FindAll(); // all matches
            if (res != null)
                foreach (SearchResult r in res)
                    Console.WriteLine(user.Properties["displayName"].Value);
        }
    }
