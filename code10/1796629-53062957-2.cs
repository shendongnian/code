    public class HomeController : Controller
    {
        private readonly IHubContext<ChatHub, IChatClient> _hubContext;
    
        public HomeController(IHubContext<ChatHub, IChatClient> hubContext)
        {
            _hubContext = hubContext;
        }
    
        public async Task<ActionResult> Index(int id) 
        {
    
             // This calls the method on the Client-side
             await _hubContext.Clients.All.DoSomething(id);
        }
    }
