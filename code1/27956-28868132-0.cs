    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm, string Command)
        {
            if (Command == "Approve")
            {
            }
            else if (Command == "Reject")
            {
            }
            return View();
        }
    }
