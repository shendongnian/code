    public ActionResult MyAction(MyEntity model)
    {
      //Here would be some validation, which returns with ModelState errors
      //Now set the validity of the modelstate as the IsValid property in your entity
      model.IsValid = ModelState.IsValid;
      return View(model);
    }
