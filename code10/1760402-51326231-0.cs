    public ActionResult SomeAction()
    {
        var predefinedRedirect = MaybeRedirect();
    
        if (predefinedRedirect != null)
            return predefinedRedirect;
    
        // The rest of the code
    }
    
    public ActionResult MaybeRedirect()
    {
        if (Session["level"] == null)
            return RedirectToAction("Home", "Whatever");
    
        if ((int)Session["level"] == 1)
            return RedirectToAction("Choose", "Whatever");
    
        ... // other conditions here
    
        return null;
    }
