    var userList = new List<User>();
    userList.Add(new User() { ID = 1, Username = "goneale" });
    userList.Add(new User() { ID = 2, Username = "Test" });
    
    List<int> IDs = new List<int>();
    //                       vv ingredients from db context
    IQueryable<User> users = Users;
    foreach(var user in userList)
    {
    	if (users.Any(x => x.Username == user.Username))
    		IDs.Add(user.ID);
    }
    IDs.Dump();
    userList.Dump();
    users.Dump();
    users = users.Where(x => IDs.Contains(x.ID));
    users.Dump();
