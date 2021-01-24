    public class UsersController : BaseApiController {
    
        IUserRepository UserRepository;
        public UsersController() // will use ninject for constructor injection
        {
            UserRepository = new UserRepository();
        }
    
        [Route("profile")]
        public IHttpActionResult GetUser()
        {
             //Request is available here
            var role = GetRole();
        }
