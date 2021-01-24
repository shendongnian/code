    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        DBEntities _context;
        public AdminController()
        {
            _context = new DBEntities();
        }
        [Route("GetUsers")]
        [HttpGet]
        public IEnumerable<string> GetUsers()
        {
    
            return new string[] { "Muhammad","Ali"};
        }
    }
