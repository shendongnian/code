    public class HomeController : ApiController
    {
        public HomeController(ITestService testService)
        {
            _testService = testService;
        }
    
        private readonly ITestService _testService;
    
        public IEnumerable<User> Index()
        {
            var result = _testService.Get();
    
            return result;
        }
    }
