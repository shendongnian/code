    // Using the delegate:
    var data = dbContext.Users.Where(usr => IsSatisfiedBy(usr)).ToList();
    // This will result in the following steps:
    var userList = ExecuteQuery("SELECT * FROM Users"); // all users are fetched.
    var satisfied = userList.Where(usr => IsSatisfiedBy(usr))
    
    // Using an expression:
    var data = dbContext.Users.Where(usr => usr.Name == "foo");
    // This will result in the following step:
    var satisfied = ExecuteQuery("SELECT * FROM Users WHERE Name = 'foo'"); // Filtered before returned to caller.
