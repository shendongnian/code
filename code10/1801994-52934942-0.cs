    [RoutePrefix("api/user")]
    public sealed class UserController : ApiController
    {
        [Route("get-user-by-mail/{email}")]
        public object GetUserByMail(string email) { }
        [Route("get-user-by-mobile/{mobile}")]
        public object GetUserByMail(string mobile) { }
    }
