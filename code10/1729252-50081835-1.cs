    [RoutePrefix("Registration")]
    public class RegistrationController : Controller {
        //GET Registration/Add/1
        //GET Registration/Add?eventId=1
        [HttpGet]
        [Route("Add/{eventId:int?}")]
        public ActionResult Add(int eventId) {
            //...
        }
    }
