    public JsonResult ProcessRequestRMA(RMAHistory_VM model) 
    {
        var RMA = new RMA_History // its Modal
        {
            Kundenavn = model.Kundenavn,
            Ordrenummer = model.Ordrenummer,
            RMATypeID = model.SelectedRMAType
        };
        db.RMA_History.Add(RMA);
        db.SaveChanges();
        return Json(model, JsonRequestBehavior.AllowGet);
    }
