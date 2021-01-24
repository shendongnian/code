        public class OptionsController : Controller
    {
        private readonly IConfiguration _configuration;
        public OptionsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var locations = new Locations();
            _configuration.GetSection("Locations").Bind(locations);
            var items = locations.location.AsEnumerable();
            return View();
        }
    }
