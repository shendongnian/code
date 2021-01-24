    public class WarningController : Controller
    {
       public ActionResult Badge()
       {
          int contWarning = 10; // temp hard coded value for demo;
          // Replace the hard coded value 
          // with your existing code to get the data from database
          return PartialView("Badge",contWarning);
       }
    }
