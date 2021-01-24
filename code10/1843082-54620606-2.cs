    public class CustomerController : ApiController {
        private readonly IUserRepository repositoty;
    
        public CustomerController(IUserRepository repositoty) {
            this.repository = repository;        
        }
    
        public IHttpActionResult SomeAction() {
            //NOTE: Only access user info in a controller action
            var userInfo = repository.GetUserInfo();
    
            //... use user info.
        }
    
        //...
    }
