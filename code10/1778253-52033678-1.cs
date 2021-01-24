        public class OptionsController : Controller
        {
        private readonly Locations _locations;
        public OptionsController(IOptions<Locations> options)
        {
            _locations = options.Value;
        }
        public IActionResult Index()
        {           
            var items2 = _locations;
            return View();
        }
         }
