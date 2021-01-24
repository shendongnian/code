    [RoutePrefix("ping")]
    public class PingController: ApiController {
    
     [HttpGet]
     [Route("")]
     public IHttpActionResult Get() {
       return Ok(DateTime.UtcNow)
     }
    
    }
