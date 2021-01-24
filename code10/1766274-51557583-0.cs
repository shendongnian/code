    [RoutePrefix("api/users")]
    public class UserController: ApiController
    {
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            // GET all users.
        }
    
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetUserById(int id)
        {
            // GET user by ID
        }
    
        [HttpPost]
        public IHttpActionResult CreateUser()
        {
            // Create User
        }
    
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateUser()
        {
            // Update User
        }
    }
