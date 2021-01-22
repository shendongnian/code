    public bool UserExists(string userName)
    {
      DirectoryEntry searchRoot = new DirectoryEntry("LDAP://dc=yourcompany,dc=com", userName, password);
      DirectorySearcher searchForUser = new DirectorySearcher(searchRoot);
    
      searchForUser.SearchScope = SearchScope.SubTree;
      searchForUser.Filter = string.Format("(&(objectCategory=Person)(anr={0}))", userName);
    
      if(searchForUser.FindOne() != null)
      {  
         return true;
      } 
      else
      {
         return false;
      }
    }
