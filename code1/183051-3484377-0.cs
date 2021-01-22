    var user = repository.Find(x => x.UserName == userName);
    if (userLogonService.IsValidUser(user, password)) {
       userLogonService.UpdateUserAsLoggedOn(user);
    }
    repository.SaveChanges();
