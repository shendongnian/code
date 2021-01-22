    using System.DirectoryServices; 
    public class test
    {
    
        private void main()
        {
            foreach (string @group in GetGroups())
            {
                Debug.Print(@group);
            }
        }
    
        public List<string> GetGroups()
        {
            DirectoryEntry objADAM = default(DirectoryEntry);
            // Binding object. 
            DirectoryEntry objGroupEntry = default(DirectoryEntry);
            // Group Results. 
            DirectorySearcher objSearchADAM = default(DirectorySearcher);
            // Search object. 
            SearchResultCollection objSearchResults = default(SearchResultCollection);
            // Results collection. 
            string strPath = null;
            // Binding path. 
            List<string> result = new List<string>();
    
            // Construct the binding string. 
            strPath = "LDAP://stefanserver.stefannet.local";
            //Change to your ADserver 
    
            // Get the AD LDS object. 
            try
            {
                objADAM = new DirectoryEntry(strPath);
                objADAM.RefreshCache();
            }
            catch (Exception e)
            {
                throw e;
            }
    
            // Get search object, specify filter and scope, 
            // perform search. 
            try
            {
                objSearchADAM = new DirectorySearcher(objADAM);
                objSearchADAM.Filter = "(&(objectClass=group))";
                objSearchADAM.SearchScope = SearchScope.Subtree;
                objSearchResults = objSearchADAM.FindAll();
            }
            catch (Exception e)
            {
                throw e;
            }
    
            // Enumerate groups 
            try
            {
                if (objSearchResults.Count != 0)
                {
                    foreach (SearchResult objResult in objSearchResults)
                    {
                        objGroupEntry = objResult.GetDirectoryEntry();
                        result.Add(objGroupEntry.Name);
                    }
                }
                else
                {
                    throw new Exception("No groups found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
    
            return result;
        }
    
    }
