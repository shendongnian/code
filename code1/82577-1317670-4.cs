    public ViewResult ThisAction()
    {
        var myObject = Session["MyObjectKey"] as MyObjectType;
        // placing this in view data provides easy access in the view.
        ViewData["MyObject"] = myObject;
        return View();
    }
