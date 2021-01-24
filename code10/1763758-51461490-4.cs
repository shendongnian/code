    public class UserController : Controller
        {
            public ActionResult Details(string id)
            {
                return Json("Test", JsonRequestBehavior.AllowGet);
            }
        }
    
        public class ClientController : UserController
        {
           
        }
