    public class MyController : Controller {
        private readonly ILocations myLocations;
    
        public MyController(ILocations myLocations) {
            this.myLocations = myLocations;
        }
    
        public ActionResult Index(int id) {
           var locations = myLocations.GetLocations();
           //linq code here that filters based on id
           return View(filteredLocations);
        }
    }
