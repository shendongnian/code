    public ActionResult NewUser()
    {
       var vm = new ResourceViewModel();
       vm.DeveloperTypes = db_RIRO.sp_GetAllDeveloperType()
                                  .Select(a=> new SelectListItem { 
                                                   Value = a.DeveloperTypeID.ToString(), 
                                                   Text= a.Developer_Type })
                                  .ToList();
       return View(vm);
    }
    [HttpPost]
    public void AddUser(ResourceViewModel model)
    {
       //check model.DeveloperTypeId
       // to do : Return something
    }
