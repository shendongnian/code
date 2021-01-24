    public class UserController : Controller
    {
        // GET: User
        public virtual ActionResult Index()
        {
            return Json("User Controller", JsonRequestBehavior.AllowGet);
        }
    }
    public class ClientController : UserController
    {
        // GET: User
        public override ActionResult Index()
        {
            return Json("Client Controller", JsonRequestBehavior.AllowGet);
        }
    }
