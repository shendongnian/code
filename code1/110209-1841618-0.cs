    namespace ContactManager.Controllers
    {
        public class GroupController : Controller
        {
            public ActionResult Index()
            {
                var groups = new List<Group>();
                return View(groups);
            }
     
        }
    }
