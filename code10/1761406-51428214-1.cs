    [RoutePrefix("drink")]
    public class DrinkController : Controller {
        [HttpGet]
        [Route("{id}")] // GET drink/coke
        public ActionResult Index(string id) {
        
            //...
            
            return View();
        }
    }
    
    
