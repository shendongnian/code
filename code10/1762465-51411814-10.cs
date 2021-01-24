    [Route("user/v1/[controller]")]
    public class UserLoginController : Controller {
        [HttpGet]
        public async Task<ActionResult<UserLogin>> Get(int userId) {
            var userLoginLogic = new UserLoginLogic();
            var model = await userLoginLogic.GetUserLogin(userId);
            if(model == null) return Ok()(); //200 with no content
            return Ok(model); //200
        }
    }
