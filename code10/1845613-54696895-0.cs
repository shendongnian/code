    public class HomeController : Controller
    {
        private readonly RequestLocalizationOptions _requestLocalizationOptions;
        public HomeController(IOptions<RequestLocalizationOptions> options)
        {
            _requestLocalizationOptions = options.Value;
        }
        //..
    }
