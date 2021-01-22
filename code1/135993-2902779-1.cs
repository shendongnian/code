    [HttpPost]
    public ActionResult UpdateSomething(UpdateHSomethingViewModel model)
    {
    	if (ModelState.IsValid)
    	{
    		// do stuff - plenty of stuff
    		// weee, we're off to see the wizard.
    		return RedirectToAction("UpdateSomethingSuccess", model);
    	}
    
        return View(model);
    }
