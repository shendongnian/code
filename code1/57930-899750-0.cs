    //
    // POST: /SomeType/Edit/5
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(Guid id, SomeType Model)
    {
        Model.EntityKey = (from SomeType s in db.SomeType
                           where s.Id == id
                           select s).FirstOrDefault().EntityKey;
        db.ApplyPropertyChanges(Model.EntityKey.EntitySetName, Model);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
