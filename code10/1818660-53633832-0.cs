    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SomeAction(SomeModel model)
    {
        // changes are made in database!!
    
        return View("View", model);
    }
    
    public ActionResult SomeOtherAction()
    {
        return SomeAction(model);
    }
