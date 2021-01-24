    namespace AuthenticationService.Controllers
    {
        [Route("api/authentication")]
        [ApiController]
        public class AuthenticationController : ControllerBase
        {
            [HttpPost("/token")]
            public IActionResult GenerateToken([FromBody] LoginRest loginRest)
            {
