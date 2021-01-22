	[ImportModelStateFromTempData]
	public ActionResult Dashboard()
	{
	    return View();
	}
	 
	[AcceptVerbs(HttpVerbs.Post), ExportModelStateToTempData]
	public ActionResult Dashboard(string data)
	{
	    if (ValidateData(data))
	    {
	        try
	        {
	            _service.Submit(data);
	        }
	        catch (Exception e)
	        {
	            ModelState.AddModelError(ModelStateException, e);
	        }
	    }
	 
	    return RedirectToAction("Dashboard");
	}
