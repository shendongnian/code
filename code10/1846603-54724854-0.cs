    public class HomeController : Controller
        {
            public ActionResult IndexLoginRegister()
            {
                return View("Index");
            }
    
            [HttpPost]
            public ActionResult IndexLoginRegister(vwSignINAndSignUP vmSign)
            {
                //Models.vwSignINAndSignUP vmSign = new Models.vwSignINAndSignUP();
                string uname = vmSign.getSignin.userName;
                string pword = vmSign.getSignin.password;
    
                //NOTE: For testing, I am directly printing using below code, otherwise I will pass to SignIn Model to verify
                return Content("Username = " + uname + ", Password = " + pword);
            }
        }
