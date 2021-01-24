    [RoutePrefix("foobar")]
    public class FooController: ApiController {
    
        //GET foobar
        [HttpGet]
        [Route("")]
        public IHttpActionResult foobar() {
            FoobarOutput model = ...
            //...
            return Ok(model);
        }
    
        //GET foobar/34
        [HttpGet]
        [Route("{id:int}")]
        public FoobarOutput foobar(int id) {
            FoobarOutput model = ...
            //...
            return Ok(model);
        }
    
    }
