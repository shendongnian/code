    var username = "wHaTeVer";
    UserPrincipal user = null;
    
    using (var context = new PrincipalContext(ContextType.Machine))
    {
    	user = new UserPrincipal(context);
    
    	using (var searcher = new PrincipalSearcher(user))
    	{
    		user = searcher.FindAll().FirstOrDefault(x => x.SamAccountName.Equals(username, StringComparison.InvariantCultureIgnoreCase)) as UserPrincipal;
    	}
    }
