    public class HomeController : Controller
    {
        private readonly AppSettings _settings;
        public HomeController(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }
    }
