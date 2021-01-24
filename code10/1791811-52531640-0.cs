     public ActionResult timelineIndex()
    { 
        var jsondata = new
        {
            data = (
                from t in ptr.GetAll()
                select (new
                {
                    id = t.pptid,
                    Owner = t.Owner,
                    Duration = t.totaldays,
                    Comp = t.Status,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate
                }))
           };
        TempData["id"] = jsondata.data.ToList();
        return View();
    }
