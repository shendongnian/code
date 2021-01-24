    [RoutePrefix("Panel")]
    public class PanelController : Controller {
        
        [HttpGet]
        [Route("")] //GET panel
        public ActionResult Index() {
            return View();
        }
        
        [HttpGet]
        [Route("another-action")] //GET panel/another-action
        public ActionResult Other() {
            return View();
        }
        
        //...other actions
    }
    
    [RoutePrefix("Home")]
    public class HomeController : Controller {
        
        [HttpGet]
        [Route("")] //GET home
        public ActionResult Index() {
            return View();
        }
        
        [HttpGet]
        [Route("contact")] //GET home/contact
        [Route("~/contact")] //GET contact
        public ActionResult Contact() {
            return View();
        }
        
        [HttpGet]
        [Route("about")] //GET home/about
        [Route("~/about")] //GET about
        public ActionResult About() {
            return View();
        }
        
        //...other actions
    }
    
