    [ApiController]
    public class VTController : ControllerBase
    {
        [HttpGet]
        [ApiVersion( "1.0" )]
        [Route( "api/v{version:apiVersion}/[controller]" )]
        public IActionResult Get( ApiVersion apiVersion ) =>
            Ok( new { Action = nameof( Get ), Version = apiVersion.ToString() } );
        [HttpGet]
        [ApiVersion( "2.0" )]
        [Route( "api/v{version:apiVersion}/[controller]" )]
        public IActionResult GetV2( ApiVersion apiVersion ) =>
            Ok( new { Action = nameof( GetV2 ), Version = apiVersion.ToString() } );
    }
