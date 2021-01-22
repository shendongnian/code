    private readonly IUserContext _userContext;
        
    public MyResolver(IUserContext userContext)
    {
    	_userContext = userContext;
    }
        
    protected override String ResolveCore(object source)
    {                    
    	// Your Logic based on user
        return TheDate;
    }
