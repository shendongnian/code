    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(Guid id, SomeType Model)
    {
        db.AttachTo(Model.GetType().Name, Model);
        Model.SomeProperty = Model.SomeProperty; // This looks hacky... =(
        db.ApplyPropertyChanges(Model.EntityKey.EntitySetName, Model);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
