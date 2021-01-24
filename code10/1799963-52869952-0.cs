    public class FooController : Controller
    {
        [Route("/Users/{userId}/Foos")]
        public IActionResult Index(int userId)
        {
            System.Web.HttpContext.Current.Session["userId"] = userId; 
            //this.TempData["userId"] = userId;
            return View();
        }
        [HttpGet]
        public JsonResult Foos()
        {
            var userId = (int)System.Web.HttpContext.Current.Session["userId"]; 
            //var userId = int.Parse(this.TempData["userId"].ToString());
            IEnumerable<Foo> foos = new Foo[0];
            //to keep this as small as possible for reproducing
            return this.Json(new { foos = foos });
        }
        [HttpPost]
        [Route("/Foos/ToggleFlag")]
        public ActionResult ToggleFlag([FromBody] Foo foo)
        {
            //delegate updating to writer; omitted for reproducibility
            return this.Ok();
        }
    }
