    public class UsersController: ApiController {
    
        //...
        //POST api/users/resetpassword
        [HttpPost]
        [Route("api/users/resetpassword")]
        public async Task<IHttpActionResult> ChangePassword([FromBody]ChangePasswordModel data) {
            //...
        }
    
        //...
    }
