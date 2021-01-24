    public ActionResult MyAction(FormCollection collection)
    {
        TempData["SuccessMessage"] = @"Action completed successfully";
        //Do stuff
        return RedirectToAction("CreateViewAction");
    }
    
    public ActionResult CreateViewAction()
    {
        ViewBag.SavedMessage = TempData["SuccessMessage"] ?? "Successfully!!!";
        return View();
    }
