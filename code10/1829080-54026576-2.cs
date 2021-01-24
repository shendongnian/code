    public class CollectController : Controller
    {
         [HttpGet]
         public IActionResult Index() => View();
    
         [HttpPost]
         public IActionResult Index([FromBody]CollectionModel model) => Content(...);
    }
