    public class FooController: ApiController {
    
        //GET foobar
        [HttpGet]
        [Route("foobar")]
        public FoobarOutput foobar() {
    
        }
    
        //GET foobar/34
        [HttpGet]
        [Route("foobar/{id}")]
        public FoobarOutput foobar(int id) {
    
        }
    
    }
