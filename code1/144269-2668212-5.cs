       foreach (ObjectStateEntry entry in
                context.ObjectStateManager.GetObjectStateEntries(
                EntityState.Added | EntityState.Modified))
            {
                  //Start pseudo code..
                  if(entry.Entity is IAuditable){
                     IAuditable temp = entry.Entity as IAuditable;
                     temp.SetInsertedOn(DateTime.Now);
                     temp.SetInsertedBy(Env.GetUser());
                     ...
                  }
            }
