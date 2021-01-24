    [System.Web.Http.RoutePrefix("v1/status")]
    public class StatusController : ApiController
    {
        [System.Web.Http.Route("")]
        public string Get()
        {
            return "V1 - OK";
        }
     }
