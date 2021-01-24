    using static System.Environment;
    [ApiVersion( "1.0" )]
    [Route( "api/v{api-version:apiVersion}/[controller]" )]
    public class HeartbeatController : Controller
    {
        [HttpGet]
        public virtual IActionResult Get() => Ok( MachineName );
    }
    [ApiVersion( "2.0" )]
    public class HeartbeatController : V1.HeartbeatController
    {
        public override IActionResult Get() => Ok( "this is version 2 " + MachineName );
    }
