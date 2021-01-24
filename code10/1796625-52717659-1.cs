    public class HomeController : Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        public HomeController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public ActionResult Index(int id) 
        {
             //// Call the DoSomething method from here, passing the id across.
             _hubContext.Clients.All.Send("DoSomething", id.ToString());
        }
    }
