    [Route("api/[controller]")]
    [MiddlewareFilter(typeof(BasicFilter))]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        // ...
    }
