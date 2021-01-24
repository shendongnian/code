    [RoutePrefix("foobar")]
    public class FooController: ApiController {
    
        //GET foobar
        [HttpGet]
        [Route("")]
        public IHttpActionResult foobar() {
            FoobarOutput model = new FoobarOutput();
            //...
            return Ok(model);
        }
    
        //GET foobar/34
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult foobar(int id) {
            FoobarOutput model = new FoobarOutput();
            //...
            return Ok(model);
        }
    
    }
