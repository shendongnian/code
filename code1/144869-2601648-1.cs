    // you can use any root DN here that you want provided your credentials
    // have search rights
    DirectoryEntry searchEntry = new DirectoryEntry("LDAP://XYZ:389");
    
    DirectorySearcher search = new DirectorySearcher(searchEntry);
    search.Filter = "(&(objectclass=user)(objectCategory=person)" +
      "(sAMAccountName=" + userName + "))";    
    
    if (search != null)
    {
      search.PropertiesToLoad.Add("sAMAccountName");
      search.PropertiesToLoad.Add("cn");
      search.PropertiesToLoad.Add("distinguishedName");
    
      log.Info("Searching for attributes");
      // find firest result
      SearchResult searchResult = null;
      using (SearchResultCollection src = search .FindAll())
      {
     if (src.Count > 0)
       searchResult = src[0];
      }
    
      if (searchResult != null)
      {
        // Get DN here
        string DN = searchResult.Properties["distinguishedName"][0].ToString();
      }
