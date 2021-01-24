    public class YourController : Controller
    {
       public ActionResult Create()
       {
            var LocationGroupDDList = _dbContext.LocationGroupDD.Select(lgdd => 
                                                 new { lgdd.LocationGroupDDId, lgdd.LocationGroupDDName }).ToList();
            ViewBag.LocationGroupDDSelectList = new SelectList(LocationGroupDDList, "LocationGroupDDId", "LocationGroupDDName");
            return View();
       }
       public JsonResult GetLocationDDByLocationGroupDD(string LocationGroupDDId)
       {
            var LocationDDList = _dbContext.LocationDD.Where(ldd => ldd.LocationGroupDDId == LocationGroupDDId)
                                                      .Select(ldd => new {ldd.LocationDDId, ldd.LocationDDName}).ToList();
            return Json(LocationDDList, JsonRequestBehavior.AllowGet);
       }
       
    }
