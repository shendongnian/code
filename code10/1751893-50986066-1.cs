    public ActionResult RMA (int Id)
        {
            VMRMA model = new VMRMA();
    
            model.Status = new SelectList(DatabaseNameSpace.RMAStatus, "ID", 
            "Status").ToList();
            //some an other stuff
            
           return View(model);
        }
