    [Route("api/v1/Admin")]
    public class AdminController : Controller {
    
        [HttpGet("keys")]
        public IActionResult GetAllKeys() { }
    
    }
