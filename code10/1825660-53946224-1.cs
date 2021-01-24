    public class HomeController : Controller
    {
        private readonly IHubContext<SomeHub> _hubContext;
    
        public HomeController(IHubContext<SomeHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task<IActionResult> Index()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveNotifiction", "Your notification message");
            return View();
        }
    }
