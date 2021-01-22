    public class TestController : Controller
    {
        [AcceptVerbs (HttpVerbs.Post)]
        public ActionResult PostAction1 (FormCollection form)
        {
            // Do something
            return View ();
        }
    
    
        [AcceptVerbs (HttpVerbs.Post)]
        public ActionResult PostAction2 (FormCollection form)
        {
            // Do something
            return View ();
        }
    }
