    **[Authorizes(Roles="Admin, Manager")]**
    namespace Supermarket.Controllers
    {
        public class userController : Controller
        {
            // GET: user
            public ActionResult Index()
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = User.Identity;
                    ViewBag.Name = user.Name;
    
                    ViewBag.displayMenu = "No";
    
                    if (isAdminUser())
                    {
                        ViewBag.displayMenu = "Yes";
                    }
                    return View();
                }
                else
                {
                    ViewBag.Name = "Not Logged IN";
                }
                return View();
            }
