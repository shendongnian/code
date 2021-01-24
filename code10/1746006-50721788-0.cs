    private IDataProtector _protector;
    
    public AccessController(IDataProtectionProvider provider)
    {
        _protector = provider.CreateProtector("MySecretKey");
    }
    
    public void ActionResult Index()
    {
        var protectedName = _protector.Protect("Tom");
        
        HttpContext.Response.Cookies.Append("name", protectedName);
       .
       . 
       .
    }
