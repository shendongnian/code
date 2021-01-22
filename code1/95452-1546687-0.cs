    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult SomeFormAction()
    { 
        //redirect them back to the original form GET here 
        RedirectToAction(stuffhere);
    }
    
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult SomeFormAction(FormCollection collection)
    { 
        //this is your original POST 
    }
