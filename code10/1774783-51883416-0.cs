    public JsonResult Lowx()
    {
        var query = db.Infos.
            Include(x => x.Profile).
            Include(x => x.Cars).
            ToList();
    
        return Json(query, JsonRequestBehavior.AllowGet);
    }
