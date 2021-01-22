    private readonly IUserContext _userContext;
        
    public MyResolver(IUserContext userContext)
    {
     _userContext = userContext;
    }
        
    protected override String ResolveCore(object source)
    {                    
     // Calculate display date based on user context
        return TheDate;
    }
