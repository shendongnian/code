    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
    
        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers() {
            //...
        }
    
        //GET: api/Users/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int id) {
           //...
        }
        //GET: api/Users/GetUserBy
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserBy([FromQuery]string username, [FromQuery]string password) {
            //...
        }
    }
