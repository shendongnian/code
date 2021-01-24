    public LCSignInManager(UserManager<Profile> userManager, IdentityDbContext db, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<Profile> claimsFactory, IOptions<IdentityOptions> optionsAccessor = null) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, new LoggerFactory().CreateLogger<LCSignInManager>(), (IAuthenticationSchemeProvider)new AuthenticationSchemeProvider(GetOption()).GetDefaultAuthenticateSchemeAsync().Result)
    {
    	_userManager = userManager;
    	this.DbContext = db;
    }
    
    private static IOptions<AuthenticationOptions> GetOption()
    {
    	var settings = new AuthenticationOptions
    		{
    			
    		};
    
    	IOptions<AuthenticationOptions> result = Microsoft.Extensions.Options.Options.Create(settings);
    
    	return result;
    }
