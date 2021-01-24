    public ViewResult Index(CreateTableModels model, ...)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        ... // code to insert new row
        ModelState.Clear();
        return View(model);
    }
