      public class LoginController : Controller
      {
        [HttpGet]
        [Route("~/{brand}/Login")]
        [Route("~/Login")]
        public ActionResult Index()
        {
          return View();
        }
      }
