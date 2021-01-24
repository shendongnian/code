    public class AuthenticationController : Controller
    {
    	private Entities db = new Entities();
    
    	public ActionResult Login()
    	{
    		return View();
    	}
    
    	public ActionResult Logout()
    	{
    		HttpContext.GetOwinContext().Authentication.SignOut();
    		return RedirectToAction("Index", "Home");
    	}
    
    	[HttpPost]
    	public ActionResult Login(string username, string password)
    	{
    		UserManager um = new UserManager();
    		bool valid = um.IsValid(username, password);
    
    		if (valid)
    		{
    			// get user role and enditem
    			USER user = db.USER.Where(u => u.USERNAME == username).First();
    			string role = db.ROLE.Where(r => r.USERID == user.USERID).FirstOrDefault().ROLENAME;
    
    			// create session
    			Claim usernameClaim = new Claim(ClaimTypes.Name, username);
    			Claim roleClaim = new Claim(ClaimTypes.Role, role);
    			ClaimsIdentity identity = new ClaimsIdentity(
    				new[] { usernameClaim, roleClaim }, DefaultAuthenticationTypes.ApplicationCookie
    			);
    
    			// auth succeed 
    			HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);
    			return RedirectToAction("Index", "Home"); 
    		}
    
    		// invalid username or password
    		ViewBag.error = "Invalid Username";
    		return View();
    	}
    }
