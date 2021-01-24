    public ActionResult Index(CaseInformation model)
    {
    	if (!model.IsValid(out var errors))
    	{
    		foreach (KeyValuePair<string, string> error in errors)
    		{
    			ModelState.AddModelError(error.Key, error.Value);
    		}                
    	}
    	if (ModelState.IsValid)
    	{
    		// it worked
    	}
    	else
    	{
    		// must be errors
    	}
    	return View();
    }
