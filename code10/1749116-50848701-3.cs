    [HttpPost]
    public ActionResult Create(CreateUserVm model)
    {
      var user = new User { UserName = model.UserName, Password = model.Password };
      user.UserLevelId = model.UserLevelId;
      yourDbContext.Users.Add(user);
      yourDbContext.SaveChanges();
      return RedirectToAction("Index");
    }
