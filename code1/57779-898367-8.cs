    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(Guid id, Department model)
    {
      db.ApplyDetachedPropertyChanges(model, x => x.Id);
      db.SaveChanges();
    }
