    [Route("api/[controller]/[action]")]
    public class TestController: Controller
    {
        [HttpGet]
        public IActionResult GetSomething([FromQuery]int id)
        {
          return Ok(id);
        }
    }
