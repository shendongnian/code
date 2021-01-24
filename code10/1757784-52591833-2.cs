    public class MyTestController : Controller
    {
        private readonly ICustomLogger _customLogger;
        public MyTestController( ICustomLogger customLogger )
        {
            _customLogger = customLogger;
        }
        public IActionResult Index()
        {
            ...
            _customLogger.Log.Debug( "Serving Index" );
            ...
        }
    }
