    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/Values")]
    [ControllerName("Values")]
    public class ValuesController : ApiController {
        
        [HttpGet]
        [Route("")] // GET api/v1.0/values
        public IHttpActionResult Get() {
            return Ok(new string[] { "value1", "value2" });
        }
        
        [HttpGet]
        [Route("{id:int}")] // GET api/v1.0/values/5
        public virtual IHttpActionResult Get(int id) {
            return Ok("value from 1");
        }
    }
    
    [ApiVersion("2.0")]
    [RoutePrefix("api/v{version:apiVersion}/Values")]
    [ControllerName("Values")]
    public class Values2Controller : ValuesController {
    
        //Will have inherited GET "api/v2.0/Values" route
        // GET api/v2.0/values/5 (Route also inherited from base controller)
        public override IHttpActionResult Get(int id) {
            return Ok("value from 2");
        }
    } 
    
