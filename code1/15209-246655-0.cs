    GetUserProperty("<myaccount>", "DisplayName");
	public static string GetUserProperty(string accountName, string propertyName)
	{
		DirectoryEntry entry = new DirectoryEntry();
		// "LDAP://CN=<group name>, CN =<Users>, DC=<domain component>, DC=<domain component>,..."
		entry.Path = "LDAP://...";
		entry.AuthenticationType = AuthenticationTypes.Secure;
		DirectorySearcher search = new DirectorySearcher(entry);
		search.Filter = "(SAMAccountName=" + accountName + ")";
		search.PropertiesToLoad.Add(propertyName);
       
		SearchResultCollection results = search.FindAll();
		if (results != null && results.Count > 0)
		{
			return results[0].Properties[propertyName][0].ToString();
		}
		else
		{
		        return "Unknown User";
		}
	}
