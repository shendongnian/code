    public ActionResult RMA()
    { 
        //DDL
        ViewBag.RMATypes = new SelectList(data.RMAType, "ID", "RMASager").ToList();
        // do some another stuff
        return View();
    }
