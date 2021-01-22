    var user = new User();
    user.Id = 2;
    user.Username = "user.name";
    user.Name = "ABC 123";
    
    context.AddToUsers(user);
    ObjectStateEntry userEntry = context.ObjectStateManager.GetObjectStateEntry(user);
    userEntry.ChangeState(EntityState.Modified);
    context.SaveChanges();
