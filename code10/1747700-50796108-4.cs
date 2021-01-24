    public class HomeController : Controller
    {
        private readonly BlexzWebDb db;
    
        public HomeController()
        {
            this.db = new BlexzWebDb();
        }
    
        //etc.
