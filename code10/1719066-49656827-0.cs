    public ActionResult TestAction(TestModel input)
    {
       // some code/validation
    
       // return the same view but with the TestModel you bind from view to a view again!
       return View(input);
    }
