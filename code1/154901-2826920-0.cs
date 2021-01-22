    [Accept(HttpVerbs.Post)] 
    public ActionResult NerdDinner(string Name) 
    { 
       ActionResult testResult = testName(Name)
       if (testResult != null) return testResult;
       ... 
       return RedirectToAction("ActionResultAAA"); 
    } 
     
    private ActionResult testName(string name) 
    { 
        if(name == null) 
        { 
            return RedirectToAction("ActionResultBBB"); 
        } 
    }
