      [IdentityBasicAuthentication]
        [Authorize]
        public class myApi1Controller : ApiController
        {
            [HttpGet]
            public string Get(string id) { 
        return "works!";
         }
        }
 
