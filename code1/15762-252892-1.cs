    using System.DirectoryServices;
    ArrayList GetAllADDomainUsers(string domainpath)
    {
       ArrayList allUsers = new ArrayList();
       DirectoryEntry searchRoot = new DirectoryEntry(domainpath);
       DirectorySearcher search = new DirectorySearcher(searchRoot);
       search.Filter = "(&(objectClass=user)(objectCategory=person))";
       search.PropertiesToLoad.Add("samaccountname");
       SearchResult result;
       SearchResultCollection resultCol = search.FindAll();
       if (resultCol != null)
       {
          for(int counter=0; counter < resultCol.Count; counter++)
          {
            result = resultCol[counter];
            if (result.Properties.Contains("samaccountname"))
            {
                allUsers.Add((String)result.Properties["samaccountname"][0]);
            }
          }
        }
        return allUsers;
    }
