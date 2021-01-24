    public class HomeController : Controller
    {
         [HttpPost]
         [CheckAntiForgeryTokenValidation]
         public ActionResult Save()
         {
             // Code of saving.
         }
    }
