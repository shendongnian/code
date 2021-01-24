    public class HomeController : Controller
    {
        private readonly ISomething something;
        public HomeController(ISomething something)
        {
            this.something = something ?? throw new ArgumentNullException(nameof(something));
        }
        public IActionResult Index()
        {
            something.DoSomething();
            return View();
        }
    }
