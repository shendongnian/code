    public ActionResult Edit(SomeVmClass model)
    {
          var entity = //fetch the entity from DB
          if(User.Identity.GetUserId() != entity.OwnerId)
                return HttpNotFound();
          // your code
    }
