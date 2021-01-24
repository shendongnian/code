    public class YourController : Controller
    {
       public ActionResult Create()
       {
            var LocationGroupDDList = _dbContext.LocationGroupDD.ToList();
            ViewBag.LocationGroupDDSelectList = new SelectList(LocationGroupDDList, "LocationGroupDDId", "LocationGroupDDName");
            return View();
       }
       public ActionResult GetLocationDDByLocationGroupDD(string LocationGroupDDId)
       {
            var LocationDDList = _dbContext.LocationDD.Where(ldd => ldd.LocationGroupDDId == LocationGroupDDId).ToList();
            return Json(LocationDDList, JsonRequestBehavior.AllowGet);
       }
       
    }
