    public JsonResult getJson()
    {
        DataContext db = new DataContext ();
    
        return this.Json(
               new {
                    Result = (from obj in db.Things select new {Id = obj.Id, Name = obj.Name})
                   }
               , JsonRequestBehavior.AllowGet
               );
    }
