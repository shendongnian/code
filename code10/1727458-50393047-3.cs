    [Authorize("ScopeCheck")]
    public class SecureController : Controller
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok(new { Message = "You are allowed" });
        }
    }
