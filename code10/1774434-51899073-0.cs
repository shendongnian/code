    [RoutePrefix("myapi/Authorize")]
    public class AuthorizeController : ApiController {
        [HttpGet, ActionName("User")]
        [Route("user")] //GET myapi/authorize/user
        [AllowAnonymous]
        public IHttpActionResult GetUser() {
            WebUser user = new WebUser();
            user.Key = Guid.Empty.ToString();
            return Ok(user);
        }
    }
