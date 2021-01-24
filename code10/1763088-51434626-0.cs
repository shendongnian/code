    [RoutePrefix("api")]
    public class MyApiController: ApiController {
        [HttpGet]
        [Route("")] // GET api
        public IHttpActionResult Get() {
            return Ok("API");
        }
    }
