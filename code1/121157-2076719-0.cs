    public ActionResult GetCustomers()
    {
        if(Request.IsAjaxRequest)
           return Json(db.GetCustomers());
    
       return View(db.GetCustomers());
    }
