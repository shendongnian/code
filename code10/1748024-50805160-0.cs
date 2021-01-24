    [Route("api/[controller]")]
    [ApiController]
    public class YourController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ApprovalController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public ActionResult<List<string>> GetAll()
        {
            using (var db = new SqlConnection(_configuration["SqlConnectionString"]))
            {
                // your code
            }
        }
