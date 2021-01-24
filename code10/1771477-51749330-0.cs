    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }
        [Route("my/url/with/as/many/slashes/as/I/want/{sessionGuid}")]
        [HttpGet("{sessionGuid}")]
        public IActionResult Get(Guid sessionGuid)
        {
            \\code         
        }
    }
