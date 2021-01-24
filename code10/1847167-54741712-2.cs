    [HttpGet]
    public ActionResult Create()
    {
        PersonModel personModel = new PersonModel();
        return View(personModel);
    }
    [HttpPost]
    public ActionResult Create(PersonModel model)
    {
        personen.Add(model);
        return Redirect("/Dashboard");
    }
