    private void GetUser(string userName, string domainName)
    {
         DirectoryEntry dirEntry = new DirectoryEntry();
         if (domainName.Length > 0)
         {
              dirEntry.Path = "LDAP://" + domainName;
         }
         DirectorySearcher dirSearcher = new DirectorySearcher(dirEntry);
         dirSearcher.SearchScope = SearchScope.Subtree;
         dirSearcher.Filter = string.Format("(&(objectClass=user)(|(cn={0})(sn={0}*)(givenName={0})(sAMAccountName={0}*)))", userName);
         var searchResults = dirSearcher.FindAll();
         //var searchResults = dirSearcher.FindOne();
         if (searchResults.Count == 0)
         {
              MessageBox.Show("User not found");
         }
         else
         {
              foreach (SearchResult sr in searchResults)
              {
                  var de = sr.GetDirectoryEntry();
                  string user = de.Properties["SAMAccountName"][0].ToString();
                  MessageBox.Show(user); 
              }        
         }
    }
