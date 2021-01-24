    [RoutePrefix("api/ControllerName")]
    public class ControllerName : ApiController {
        //GET api/ControllerName?p1=1&p2=2&p3=3&p4=4&p5=5
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetItemByNameAndId(string p1, string p2, string p3, string p4, string p5) {
            //...
            return Ok(someResult);
        }
    }
