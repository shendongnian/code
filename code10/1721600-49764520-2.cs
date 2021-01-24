    public IActionResult ViewModelDemo()
    {
        var vm = new ViewModelDemoVM();
        vm.Companies = db.Companies
                         .Select(a => new CompanyVm { Name = a.Name,
                                                      Contacts = a.Contacts
                                                                  .Select(c => new ContactVm
                                                                         { Name = c.Name })}
                          ).ToList();
        return View(vm);
    }
