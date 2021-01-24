    public JsonResult GetNames(string date)
     {
       List<Provider> list = new List<Provider>();
       // [...]
       return Json(list, JsonRequestBehavior.AllowGet);
    }
