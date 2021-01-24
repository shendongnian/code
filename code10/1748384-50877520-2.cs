    [ApiVersion("1.0")]
    [RoutePrefix("api/v{version:apiVersion}/Values")]
    [ControllerName("Values")]
    public class ValuesController : ApiController {
        // GET api/v1.0/values
        [Route("")]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }
        
        // GET api/v1.0/values/5
        [Route("{id:int}")]
        public virtual string Get(int id) {
            return "value from 1";
        }
    }
    
    [ApiVersion("2.0")]
    [RoutePrefix("api/v{version:apiVersion}/Values")]
    [ControllerName("Values")]
    public class Values2Controller : ValuesController {
        //Will have inherited GET "api/v2.0/Values" route
        // GET api/v2.0/values/5 (Route also inherited from base controller)
        public override string Get(int id) {
            return "value from 2";
        }
    } 
    
