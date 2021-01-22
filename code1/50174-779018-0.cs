    public bool IsAuthenticated(String domain, String username, String pwd)
    {
      String domainAndUsername = domain + "\\" + username;
      DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);
			
      try
      {	//Bind to the native AdsObject to force authentication.			
         Object obj = entry.NativeObject;
         DirectorySearcher search = new DirectorySearcher(entry);
         search.Filter = "(SAMAccountName=" + username + ")";
         search.PropertiesToLoad.Add("cn");
         SearchResult result = search.FindOne();
         if(null == result)
         {
             return false;
         }
         //Update the new path to the user in the directory.
         _path = result.Path;
         _filterAttribute = (String)result.Properties["cn"][0];
      }
      catch (Exception ex)
      {
         throw new Exception("Error authenticating user. " + ex.Message);
      }
         return true;
     }
