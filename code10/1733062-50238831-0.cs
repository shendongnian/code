    [RoutePrefix("api/Test")]
    public class TestController : ApiController {
        private myEntity db = new myEntity();
        //GET api/Test
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll() {
            //...code removed for brevity
        }
    
        //GET api/Test/1
        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetById(int id) {
            //...code removed for brevity                
        }
    }
