    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IActionResult Index()
        {
            var x = (string)HttpContext.Items["mw-message1"];
            return new JsonResult(new {
                MW1 = x,
                Hello= "Hello",
            });
        }
    }
