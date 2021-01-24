    //namespace Testy20161006.Controllers
    public class ReloadPageViewModel
    {
        [Display(Name = "Link")]
        public string Link { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult ToIndex()
        {
            //put a breakpoint here to go to this action,
            //after url change
            ReloadPageViewModel DLink = new ReloadPageViewModel();
            DLink.Link = "http://somelink";
            return View(DLink);
        }
              
        public ActionResult Tut116()
        {
            ViewBag.MyURL = "http://www.Google.com";
            ReloadPageViewModel DLink = new ReloadPageViewModel();
            //don't show you this property, I concentrate on your main problem,
            //which is, how a button click, can change href
            DLink.Link = "6";
            return View(DLink);
        }
