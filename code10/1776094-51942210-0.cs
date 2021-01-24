      public class BaseController : Controller
        {
            private string _id = null;
            protected string ID
            {
                get
                {
                    var cookie = Request.Cookies.Get("ID");
                    if (cookie != null)
                    {
                        _id = cookie.Value;
                    }
    
                    return _id;
                }
            }
        }
    
            public class HomeController : BaseController
            {
                public ActionResult Index()
                {
                    var test = ID;
    
                    ViewBag.Title = "Home Page";
    
                    return View();
                }
            }
