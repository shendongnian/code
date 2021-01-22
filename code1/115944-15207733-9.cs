    public class AccountController : Controller
        {
            UserApplication userApp = new UserApplication();
            SessionContext context = new SessionContext();
    
            public ActionResult Login()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Login(User user)
            {
                var authenticatedUser = userApp.GetByUsernameAndPassword(user);
                if (authenticatedUser != null)
                {
                    context.SetAuthenticationToken(authenticatedUser.UserId.ToString(),false, authenticatedUser);
                    return RedirectToAction("Index", "Home");
                }
               
                return View();
            }
    
            public ActionResult Logout()
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
