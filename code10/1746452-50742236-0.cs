       [HttpPost]
       public JsonResult ProcessRequestRMA(int? id ,string kundenavn, string ordrenummer)
       {
    //var SaveDb = db.RMA_History.Where(a => a.Id == id).FirstOrDefault();
    //if (SaveDb == null)
    //    db.RMA_History.Add(new RMA_History
    //    {   
    //        Kundenavn = kundenavn,
    //       Ordrenummer = ordrenummer,
    //   });
    // db.SaveChanges();
    return Json(true, JsonRequestBehavior.AllowGet);
    }
