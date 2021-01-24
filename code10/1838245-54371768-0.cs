    public class HomeController : Controller
    {
        public ActionResult HideQueryString()
        {
            return View("Tut143");
        }
        public ActionResult Print(string location, string startDate, string endDate)
        {
            //print here
            return RedirectToAction("HideQueryString");
        }
        public ActionResult Tut143()
        {
            return View();
        }
