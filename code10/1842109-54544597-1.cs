    public class ValuesController : ControllerBase
    {
        private readonly IIPChecker _ipChecker;
        public ValuesController(IIPChecker ipChecker)
        {
            _ipChecker = ipChecker;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var isValid = _ipChecker.IsSafe(HttpContext.Connection.RemoteIpAddress);
            .....
        }
    }
