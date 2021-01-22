    public IEnumberable<VerboseUserInfo> GetAllUsers()
    {
    	foreach(UserId in userLookupList)
    	{
    		VerboseUserInfo info = new VerboseUserInfo();
    
    		info.Load(ActiveDirectory.GetLotsOfUserData(UserId));
    		info.Load(WebSerice.GetSomeMoreInfo(UserId));
    	
    		yield return info;
    	}
    }
