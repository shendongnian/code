    public class CollectController : Controller
    {
         [HttpGet]
         public IActionResult Index() => View();
    
         [HttpPost]
         public IActionResult Index([HttpBody]CollectionModel model) => Content(...);
    }
