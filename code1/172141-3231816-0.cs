    public ActionResult Index()
    {
        var model = new MyViewModel();
        model.PERSON = FetchPerson();
        return View(model);
    }
    [HttpPost]
    public ActionResult Edit(MyViewModel model) 
    {
        _MyRepository.Save(model);
        return View(model);
    }
