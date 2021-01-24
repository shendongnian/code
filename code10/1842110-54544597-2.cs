    public class IpCheckController : ControllerBase
    {
        private readonly IIPChecker _ipChecker;
        public IpCheckController(IIPChecker ipChecker)
        {
            _ipChecker = ipChecker;
        }
        private bool IsSafe => _ipChecker.IsSafe(HttpContext.Connection.RemoteIpAddress);
    }
