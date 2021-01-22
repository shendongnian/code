    [DataForMasterPage]
    public class CategoriaController : Controller
    {
          public ActionResult Index()
          {
                ViewData["Message"] = "Welcome to ASP.NET MVC!";
                return View();
          }
    }
