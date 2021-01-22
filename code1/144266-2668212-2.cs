       foreach (ObjectStateEntry entry in
                context.ObjectStateManager.GetObjectStateEntries(
                EntityState.Added | EntityState.Modified))
            {
                  //Start pseudo code..
                  if(entry.Entity is IUpdatable){
                     IUpdateable temp = entry.Entity as IUpdatable;
                     temp.SetInsertedOn(DateTime.Now);
                     temp.SetInsertedBy(Env.GetUser());
                     ...
                  }
            }
