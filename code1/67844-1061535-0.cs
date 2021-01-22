    namespace MyProject.Model
    {
        public class Website
        {
            public int WebsiteID { get; set }
            public string Name { get; set }
            public string Url { get; set }
            public string Author { get; set }
        }
    
        public class WebsiteRepository
        {
            public Website Read(int id) { // read from database }
            public void Write(Website website) { // write to database }
            public website[] GetWebsites { }
        }
    }
    
    namespace MyProject.Controllers
    {
        public class WebsiteController
        {
            WebsiteRepository repository = new WebsiteRepository();
    
            ActionResult Index()
            {
                Website[] websites = repository.GetWebsites();
                return View(websites);
            }
        }
    }
