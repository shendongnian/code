    [ButtonHandler()]
    public ActionResult AddDepartment(Company model)
    {
        model.Departments.Add(new Department());
        return View(model);
    }
