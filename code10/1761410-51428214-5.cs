    [RoutePrefix("drink")]
    public class DrinkController : Controller {
        [HttpGet]
        [Route("{name}")] // GET drink/coke
        public ActionResult Index(string name) {
        
            //...use name to get model
            
            return View();
        }
        
        //..
    }
    
