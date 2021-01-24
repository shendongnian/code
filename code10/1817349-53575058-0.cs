    [Authorize]
    [RoutePrefix("api/LoginVerification")]
    public class LoginVerificationController : ApiController {
        // GET api/<controller>
        [HttpGet]
        [Route("")]
        public IEnumerable<string> Get() {
            return new string[] { "value1", "value2" };
        }
    
        // GET api/<controller>/5
        [HttpGet]
        [Route("{id:int}")]
        public string Get(int id) {
            return "value";
        }
    
        // POST api/<controller>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody]string value) {
            //...
        }
    
        // PUT api/<controller>/5
        [HttpPut]
        [Route("{id:int}"]
        public void Put(int id, [FromBody]string value)
        {
        }
        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("{id:int}"]
        public void Delete(int id)
        {
        }
    }
