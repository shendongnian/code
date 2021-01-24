    public class HomeController : Controller
    {
        ...
        public JsonResult GetValue()
        {
            string result = null;
            // This is where you check database for the "N" or "S" value
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
