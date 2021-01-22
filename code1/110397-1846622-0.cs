    string filter = "(&(&(objectclass=user)(objectcategory=person))" + 
                    "sAMAccountName=username)";
    NetworkCredential credentials = new NetworkCredential(...);
    LdapDirectoryIdentifier directoryIdentifier = 
       new LdapDirectoryIdentifier("server", 389, false, false);
    using (LdapConnection connection = 
       new LdapConnection(directoryIdentifier, credentials, AuthType.Basic))
    {
        connection.Timeout = new TimeSpan(0, 0, 30);
        connection.SessionOptions.ProtocolVersion = 3;
        SearchRequest search = 
            new SearchRequest(query, filter, SearchScope.Base, "mail");
        SearchResponse response = connection.SendRequest(search) as SearchResponse;
        foreach(SearchResultEntry entry in response.Entries)
        {
            Console.WriteLine(entry.Attributes["mail"][0]);
        }
    }
