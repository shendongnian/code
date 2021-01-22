    [MyCustomFilter]
    public class MyBaseController : Controller
    {
        // I am the application's base controller with the filter,
        // so any derived controllers will ALSO get the filter (unless they override/Ignore)
    }
    public class HomeController : MyBaseController
    {
        // Since I derive from MyBaseController,
        // all of my action methods will also get the filter,
        // unless they specify otherwise!
        
        public ActionResult FilteredAction1...
        public ActionResult FilteredAction2...
        
        [MyCustomFilter(Ignore)]
        public ActionResult MyIgnoredAction...    // I am ignoring the filter!
        
    }
    
    [MyCustomFilter(Ignore)]
    public class SomeSpecialCaseController : MyBaseController
    {
        // Even though I also derive from MyBaseController, I can choose
        // to "opt out" and indicate for everything to be ignored
        
        public ActionResult IgnoredAction1...
        public ActionResult IgnoredAction2...
        
        // Whoops! I guess I do need the filter on just one little method here:
        [MyCustomFilter]
        public ActionResult FilteredAction1...
    
    }
