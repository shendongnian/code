    namespace deliver_data.wwwroot.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class r_wController : ControllerBase
    {
       // GET: api/r_w
       [HttpGet]
       public IHttpActionResult Get()
       {
           return new string[] { "value1", "value2" };
       }
