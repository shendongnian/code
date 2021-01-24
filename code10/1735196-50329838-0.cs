    [RoutePrefix("subroute")]
    public class HomeController : ApiController {
        [HttpGet]
        [Route("GetInfo/{param1}/{param2}")]
        public IHttpActionResult GetInfo(string param1, string param2) {
            //...
        }
    }
