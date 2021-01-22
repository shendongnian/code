    public class PostController : Controller {
        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveDraft(…) {
            //…
        }
    
        [HttpParamAction]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Publish(…) {
            //…
        } 
    }
 
