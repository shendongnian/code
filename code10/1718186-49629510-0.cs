    DirectoryEntry searchRoot;
    DirectorySearcher search;
    
    public SearchResultCollection SearchAd(string prop){
    	// Define other methods and classes here
    	string ldapPath = "LDAP://OU=Ingegneria,DC=xxx,DC=xxx";
    	searchRoot = searchRoot ?? GetEntry(ldapPath, adminUser, adminPassword);
    	
    	
    	search = search ?? new DirectorySearcher(searchRoot)
    	{
    		SearchScope = SearchScope.Subtree,
    		Filter = "(&" +
    		"(objectClass=user)" +
    		"(givenname=s*)" +
    		"(samaccountname=*100)" +
    	")"
    	};
    	
    	search.PropertiesToLoad.Add(prop);
    	return search.FindOne();
    } 
