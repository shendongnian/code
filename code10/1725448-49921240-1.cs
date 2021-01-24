    public class AnyController : Controller
    {   
        public AccountController(UserManager<ApplicationUser> userManager)
    	{
    		_userManager = userManager;
    	}
    	
    	public async void GetCurrentUserId()
    	{
           var user=await _userManager.GetUserAsync(this.User);
    	}
    }
