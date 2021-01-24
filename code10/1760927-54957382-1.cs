    [Area("[areaname]")]
    [Route("[areaname]/[controller]")]
    public class YourController : Controller
    {
        public IActionResult Index() => View();
    }
