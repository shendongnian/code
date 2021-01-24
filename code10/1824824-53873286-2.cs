    class SomeController : Controller
    {
        private readonly IHubContext<MyHub> _hubContext;
        public SomeController(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }
    }
