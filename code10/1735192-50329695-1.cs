    [RoutePrefix("subroute")]
    public class HomeController : ApiController {
        //Matches GET subroute/GetInfo?param1=somestring&param2=somestring
        [HttpGet]
        [Route("GetInfo")]
        public IHttpActionResult GetInfo(string param1, string param2) {
            //...
        }
    }
