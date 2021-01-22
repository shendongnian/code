    public ActionResult Edit(int id)
    {
        return Edit(id, "Address", "Index");  // return to the Index page
    }
    public ActionResult Edit(int id, string controller, sting action)
    {
      Address address = MyDatabase.GetAddress(id);
      ViewData["Action"] = action;
      ViewData["Controller"] = controller;
      return View(address);
    }
    public ActionResult Edit(Address address)
    {
        MyDatabase.Save(address);
    
        // Read redirect from Form
        string action = Request.Form["Action"];
        string controller = Request.Form["Controller"];
        return RedirectToAction(action, controller);
    }
