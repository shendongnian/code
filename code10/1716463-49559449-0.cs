    public ActionResult IndexByName(string lastName)
    {
        return View("Index", myObject);
    }
    
    public ActionResult SomeOtherAction(IFormCollection collection)
    {
        if (collection["somekey"] == "search")
        {
            // This will return the result of IndexByName()
            // and exist the SomeOtherAction method
            return IndexByName(collection["lastname"]); 
        }
        else
        {
            // This will return the View SomeOtherView
            // and exist the SomeOtherAction method
            return View("SomeOtherView");
        }
    
        // In theorty this would  return an HTTP 200
        // but it is NEVER hit. All execution paths 
        // within this method resolved before we 
        // ever got here.
        return Ok();
    }
