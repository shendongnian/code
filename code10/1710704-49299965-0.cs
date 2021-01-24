    public IActionResult Index()
    {    
      List<ApplicationRoleViewModel> models = new List<ApplicationRoleViewModel>();
      models = _roleManager.Roles.Select(r => new ApplicationRoleViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
                // notice I am not assigning NumberOfUsers here.See further down...
            }).ToList();
            foreach(var m in models)
            {
              m.NumberOfUsers = _userManager.GetUsersInRoleAsync(m.Name).Result.Count;
            }
            return View(models);
    }
