      [Route("api/[controller]")]
        public class TestController : ApiController
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
