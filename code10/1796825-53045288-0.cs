    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase {
        //GET api/users/register
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register() {
            //...
        } 
    }
