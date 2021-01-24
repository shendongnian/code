    namespace WebApplication2.Controllers
    {
    public class HomeController : Controller
    {
        // GET: Home
    
        Class1 cs = new Class1();
        public ActionResult Index()
        {
            if(TempData["A"]==null)
            {
    
                cs.name = "hi";
                TempData["A"] = "B";
            }
    
            return View(cs);
        }
    
        public ActionResult A(string name)
        {
           cs.age ="hello";
           cs.name = name;
           return View("Index", cs);
    
        }
    
    
        }
    }
