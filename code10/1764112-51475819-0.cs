    public class ErrorsController : Controller
    {
        // GET: Errors/Unauthorized
        public ActionResult Unauthorized()
        {
            return new HttpStatusCodeResult(401);
        }
        // GET: Errors/Forbidden
        public ActionResult Forbidden()
        {
            return new HttpStatusCodeResult(403);
        }
        // Additional Errors
    }
