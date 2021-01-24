    public ActionResult TestViewToString()
    {
    	var viewModel = new TestViewModel();
    	// Populate ViewModel here ...
    
    	string data = RenderViewToString(ControllerContext, "~/Views/SomePath/SomeViewOne.cshtml", viewModel, true);
    	return Json(data, JsonRequestBehavior.AllowGet);
    }
