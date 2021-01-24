      [Route("api/[controller]")]
        public class TestController : Controller
        {
    
            [HttpGet]
            public async Task<IActionResult> Daily([FromQuery] DailyModel model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
    
              ...
            }
        }
