    public class HomeController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        public HomeController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task<ActionResult> Index(int id) 
        {
             //// Call the DoSomething method from here, passing the id across.
             await _hubContext.Clients.All.SendAsync("DoSomething", id);
        }
    }
