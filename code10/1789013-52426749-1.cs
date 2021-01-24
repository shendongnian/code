    public class AnyController : BaseController
    {
        public ActionResult GetResponseType(Response response)
        {
            return ResponseType(response);
        }
    }
