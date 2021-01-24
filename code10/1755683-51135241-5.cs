    public ActionResult RMA()
    { 
        //DDL
        var model = new RMAHistory_VM
        {
            RMATypes = new SelectList(data.RMAType, "ID", "RMASager").ToList();
        };
        // do some another stuff
        return View(model);
    }
