    [RoutePrefix("api/test")]    
    public class TestController : ApiController {
        //GET api/test/ping
        [HttpGet] [Route("ping")]
        public IHttpActionResult Ping() {
            return Ok("HELLO");
        }
        //GET api/test/echo/hello%20world
        [HttpGet] [Route("echo/{message}")]
        public IHttpActionResult Echo(string message) {
            if(message == null)
                return BadRequest();
            return Ok(message);
        }
    }
