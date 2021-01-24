    public class HomeController : Controller
    {
        private readonly TicketsystemContext context;
        public HomeController(TicketsystemContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(context.User.First());
        }
    }
