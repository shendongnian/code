    [HttpPost]
    public ActionResult Create(MyCreateViewModel collection)
    {
        MyCreateViewModel myCVM = new MyCreateViewModel();
        TryUpdateModel(myCVM);
        ValidateInput(myCVM);
        if (ModelState.IsValid == false) return View(collection);
