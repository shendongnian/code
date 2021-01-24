    public MyAppController : Controller 
    {
	    [HttpPost]
        public JsonResult MyAction(string btnId)
        {
		    Debug.WriteLine("btnId: {0}", btnId);
		
    		return Json(new{ ButtonId: btnId });
	    }
    }
