    List<string> lstUsersToRemove = new List<string>() {"TEST/acuba","TEST/test2", "TEST/test3" };
        
    foreach(string userName in lstUsersToRemove)
    {
        var user = listUsers.SingleOrDefault(x => x.UserName.Replace("//", "/") == userName.Replace("//", "/"));
        if(user != null)
            listUsers.Remove(user);
    }
