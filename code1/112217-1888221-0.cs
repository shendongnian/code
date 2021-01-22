    public class SomeController : Controller
    {
        public ActionResult SomeAction()
        {
            // ... do stuff ...
            TempData["SomeKey"] = "SomeController.SomeAction";
            return RedirectToAction("SomeOtherAction", "SomeOtherController");
        }
    }
    
    public class SomeOtherController : Controller
    {
        public ActionResult SomeOtherAction()
        {
            if (TempData.ContainsKey("SomeKey"))
            {
                // ... do stuff ...
            }
            // etc...
        }
    }
