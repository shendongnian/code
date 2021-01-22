    public ActionResult Edit(string id)
    {
      User myModel = UserServiceFactory.GetUser(id);
      myModel.MonthOfBirth = -1;
      return View(myModel);
    }
