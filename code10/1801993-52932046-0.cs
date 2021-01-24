     //This is important
    [Route("api/[controller]/[action]")]
    public class PingController : Controller
    {
        
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }
    }
