    public class HomeController : Controller
        {
            private IHostingEnvironment _env;
            public HomeController(IHostingEnvironment env)
            {
                _env = env;
            }
            public IActionResult Index()
            {
                var webRoot = _env.WebRootPath;
                var file = System.IO.Path.Combine(webRoot, "test.txt");
                System.IO.File.WriteAllText(file, "Hello World!");
                return View();
            }
        }
