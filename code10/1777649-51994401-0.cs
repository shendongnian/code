    foreach (SearchResult result in search.FindAll())
    {
        ResultPropertyCollection resultProperties = result.Properties;
        foreach (string groupMemberDN in resultProperties["uniqueMember"])
        {
            DirectoryEntry directoryMember = new DirectoryEntry(
                "LDAP://123.45.678.9:389/" + groupMemberDN, 
                "uid=test_user, ou=test, dc=test2,dc=test3", "test-abc", 
                AuthenticationTypes.None);
            GroupMembers.Add(directoryMember.Properties["mail"][0].ToString());
        }
    }
    // Now that our collection is fully populated, output it to the console
    foreach (string member in GroupMembers)
    {
        Console.WriteLine(member);
    }
