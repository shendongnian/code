    static string[] userIDs = new string[] "user1","user2","user3","user4","user5","user6","user7","user8"...,"user1300"};
    DirectoryEntry searchRoot = new DirectoryEntry("LDAP://cn=Users,dc=YourComp,dc=com");
    
    List<string> nonExistingUsers = new List<string>();
    List<string> ExistingUsers = new List<string>();
    foreach (string s in userIDs)
    {
       DirectorySearcher search = new DirectorySearcher(searchRoot);
       search.SearchScope = SearchScope.Subtree;
       search.Filter = string.Format("(&(objectCategory=person)(anr={0}))", s);
       SearchResultCollection resultCollection = ds.FindAll();
       if(resultCollection != null && resultCollection.Count > 0)
          ExistingUsers.Add(s);
       else
          nonExistingUsers.Add(s);
    }
