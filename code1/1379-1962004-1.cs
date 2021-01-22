    public static IUser CurrentUser
    {
    	get
    	{
    		return CachePattern<IUser>("CurrentUserKey", () => repository.NewUpUser());
    	}
    }
