    using System.Web.Http
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        DBEntities _context;
        public AdminController()
        {
             _context = new DBEntities();
        }
        [HttpGet]
        [Route("GetUsers")]
        public IEnumerable<string> GetUsers()
        {
            return new string[] { "Muhammad","Ali"};
        }
    }
