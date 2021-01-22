    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(Guid id, Department model)
    {
      var entitySetName = db.DefaultContainerName + "." + model.GetType().Name;
      var entityKey = new System.Data.EntityKey(entitySetName, "Id", model.Id);
      db.Attach(new Department{Id = id, EntityKey = entityKey});
      db.AcceptAllChanges();
      db.ApplyPropertyChanges(entitySetName, model);
      db.SaveChanges();
    }
