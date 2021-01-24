    [RoutePrefix("Load")]
    public class LoadController : ApiController
    {
        [HttpGET, Route("bla")]
        public string Bla()
        {
            return "bla";
        }
    }
