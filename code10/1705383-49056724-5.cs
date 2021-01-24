    [RoutePrefix("api/Doors")]
    public class DoorsController : ApiController {
    
        //matches GET api/doors/5
        [HttpGet]
        [Route("{organizationSys:int}")]
        public IHttpActionResult Get(int organizationSys) {
            //....
        }
        
        //matches GET api/doors/5/1
        [HttpGet]
        [Route("{organizationSys:int}/{id:int}")]
        public IHttpActionResult Get(int organizationSys, int id) {
            ....
        }    
        
        //matches POST api/doors
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody]Doors door) {
            //....
        }
    
        //matches PUT api/doors
        [HttpPut]
        [Route("")]    
        public IHttpActionResult Put([FromBody]Doors door) {
            //....
        }
       
        //matches DELETE api/doors/5/1
        [HttpDelete]
        [Route("{organizationSys:int}/{id:int}")]    
        public IHttpActionResult Delete(int organizationSys, int id) {
            //....
        }    
    }
