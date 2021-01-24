    public class AdministrationController : Controller
    {
        public ActionResult Users()
        {
        }
    
        [Route("users/new")] //This is the important part here
        public ActionResult NewUser()
        {
        }
    }
