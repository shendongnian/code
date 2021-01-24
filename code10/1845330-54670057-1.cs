    [System.Web.Http.RoutePrefix("v2/status")]
    public class Status2Controller : ApiController
    {
        [System.Web.Http.Route("")]
        public string Get()
        {
            return "V2 - OK";
        }
     }
