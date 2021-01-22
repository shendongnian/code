    using System.DirectoryServices;
    ArrayList GetADGroupUsers(string groupName)
    {    
       SearchResult result;
       DirectorySearcher search = new DirectorySearcher();
       search.Filter = String.Format("(cn={0})", groupName);
       search.PropertiesToLoad.Add("member");
       result = search.FindOne();
       ArrayList userNames = new ArrayList();
       if (result != null)
       {
	   for (int counter = 0; counter < 
	          result.Properties["member"].Count; counter++)
	   {
	      string user = (string)result.Properties["member"][counter];
	            userNames.Add(user);
           }
       }
       
       return userNames;
    }
