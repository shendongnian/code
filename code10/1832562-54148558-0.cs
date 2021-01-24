    [RoutePrefix("api")]
    public class MyEmptyController : ApiController {
        //GET api
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get() { 
            return StatusCode(HttpStatusCode.NoContent); //204
        }
    }
