      [Route("api/[controller]")]
        public class TestController : Controller
        {
    
            [HttpGet("daily/{state}/{year}/{month}/{day}")]
            public async Task<IActionResult> Daily([FromRoute] DailyModel model)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
    
              ...
            }
        }
