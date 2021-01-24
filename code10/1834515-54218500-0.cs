    public class HomeController 
    { 
        private readonly Connector _connector;
        public HomeController(Connector connector)
        {
            _connector = connector;
        }
        public IActionResult Index()
        {
            var x = _connector.DoSomething();
            // ...
        }
