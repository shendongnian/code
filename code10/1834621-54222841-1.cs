    [Authorize(Policy = Common.Security.Policies.ApiUser)]
    [Route("api/[controller]")]
    [Benchmark, ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected BaseController()
        { }
    }
