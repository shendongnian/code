    [Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Json(User.Identity.Name);
        }
    }
