    [AcceptVerbs(HttpVerbs.Get)]
    public ViewResult Create()
    {
      // Loads default values
      Instructor i = new Instructor();
      return View("Create", i);
    }
    [AcceptVerbs(HttpVerbs.Get)]
    public ViewResult Create()
    {
      // Does not load default values from instructor
      return View("Create");
    }
