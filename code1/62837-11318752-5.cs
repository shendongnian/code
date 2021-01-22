    private class RedirectController : Controller
    {
        public ActionResult RedirectToSomewhere()
        {
            return RedirectToAction("Action", "Controller");
        }
    }
