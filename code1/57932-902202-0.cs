    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(Guid id, SomeType Model)
    {
        db.AttachTo(Model.GetType().Name, Model);
    
        ObjectStateManager stateMgr = db.ObjectStateManager;
        ObjectStateEntry stateEntry = stateMgr.GetObjectStateEntry(model);
        stateEntry.SetModified(); // Make sure the entity is marked as modified
        //db.ApplyPropertyChanges(Model.EntityKey.EntitySetName, Model);
    
        db.SaveChanges();
        return RedirectToAction("Index");
    }
