    namespace Testy20161006.Controllers
    {
        public class csUser
        {
            public string UserEmail { get; set; }
            public string UserMobile { get; set; }
            public string UserPassword { get; set; }
        }
        public class HomeController : Controller
        {
            [HttpPost]
            public ActionResult InsertAjax(csUser csUser)
            {
                //!! Put a breakpoint here and see the values passed in for csUser
                return Json(new
                {
                    ap = "dh"
                }
                    , @"application/json");
            }
