    [HttpPost]
    public ActionResult AnAction(IndexVM model)
    {
        ModelState.Remove("Child.ChildProperty1");
        ModelState.Remove("Child.ChildProperty2");
	    if (!ModelState.IsValid)
		{
			// put code here
		}
		// carry on 
		return View(model)
	}
