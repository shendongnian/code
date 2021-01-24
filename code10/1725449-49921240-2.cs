    public class AnyController : Controller
    {   
        public AnyController (UserManager<ApplicationUser> userManager)
    	{
    		_userManager = userManager;
    	}
    	
    	public async void GetCurrentUserId()
    	{
           var user=await _userManager.GetUserAsync(this.User);
    	}
    }
