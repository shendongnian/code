    public ActionResult One() {
      // do stuff
      return View("Index", myModel);
    }
    public ActionResult Two() {
      // do stuff
      return View("Index", myOtherModel); // Same View
    }
