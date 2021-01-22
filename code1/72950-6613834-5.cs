    public JsonResult getJson()
    {
        GlobalDataContext db = new GlobalDataContext();
    
        return this.Json(
                          (from obj in db.Environments select new {Id = obj.Id, Name = obj.Name})
                          
                          , JsonRequestBehavior.AllowGet
                       );
    }
