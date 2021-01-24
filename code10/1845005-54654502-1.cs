    public class ValidationController : Controller
    {
        public JsonResult IsUserGuidEquals(string substituteUserGid, string userGid)
        {
            return Json(substituteUserGid != userGid,JsonRequestBehavior.AllowGet);
        }
     }
