    public class ProfileService : IProfileService
    {
    	protected UserManager<ApplicationUser> _userManager;
    
    	public ProfileService(UserManager<ApplicationUser> userManager)
    	{
    		_userManager = userManager;
    	}
    
    	public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    	{
    		var user = await _userManager.GetUserAsync(context.Subject);
    		var roles = await _userManager.GetRolesAsync(user);
    		var claims = new List<Claim>
    		{
    			new Claim(JwtClaimTypes.Role, roles.Any() ? roles.First() : "Standard")
    		};
    
    		context.IssuedClaims.AddRange(claims);
    	}
    
    	public async Task IsActiveAsync(IsActiveContext context)
    	{
    		var user = await _userManager.GetUserAsync(context.Subject);
    		context.IsActive = (user != null) && user.LockoutEnabled;
    	}
    }
