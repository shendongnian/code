    // Use the repo
    using (var userRepo = new UserRepo())
    {
        var allUsers = userRepo.GetAll();
        var user = userRepo.Get().FirstOrDefault(m => m.Username == "myUsername");
    }
    // Or just use the data context
    using (var db = new AppDataContext())
    {
        var allUsers = db.Users.ToList(); // Get all users
        var user = db.Users.FirstOrDefault(m => m.Username == "myUsername");
    }
	
