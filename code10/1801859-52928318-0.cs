    public class HomeController : Controller
    {
    // GET: Student
    public HomeController()
    {
    }
    public ActionResult Index()
    {
        TempData["name"] = "Test data";
        TempData["age"] = 30;
        return View();
    }
    public ActionResult About()
    {
        string userName;
        int userAge;
        
        if(TempData.ContainsKey("name"))
            userName = TempData["name"].ToString();
    
        if(TempData.ContainsKey("age"))
            userAge = int.Parse(TempData["age"].ToString());
    
        // do something with userName or userAge here 
        return View();
    }
    }
