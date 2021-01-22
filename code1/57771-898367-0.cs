    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(Guid id, Department Model)
    {
      var entitySetName = db.DefaultContainerName + "." + Model.GetType().Name;
      var entityKey = new System.Data.EntityKey(entitySetName, "Id", Model.Id);
      db.Attach(new Department{Id = id, EntityKey = entityKey});
      db.AcceptAllChanges();
      db.ApplyPropertyChanges(entitySetName, Model);
      db.SaveChanges();
    }
