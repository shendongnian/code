    var user = repository.Find(x => x.UserName == userName);
    if (user.CheckPassword(password)) {
        user.LogOnNow();
    }
    repository.SaveChanges();
