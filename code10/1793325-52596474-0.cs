    [Route("/")]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ...
        }
        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            ...
        }
    }
