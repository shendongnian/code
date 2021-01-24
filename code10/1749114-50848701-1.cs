    public ActionResult Create()
    {
      var vm = new CreateUserVm();
      vm.UserLevels = GetTypes();
      return View(vm);
    }
    private List<SelectListItem> GetTypes()
    {
        return db.UserLevels.Select(a => new SelectListItem
        {
            Value = a.Id.ToString(),
            Text = a.Name
        }).ToList();
    }
