    foreach (var name in new string[] { "Tim", "Bob", "John" })
    {
        var u = from users in db.Users
                where users.username == name
                select users;
        
        if (u.Count() == 0)
        {
           User user = new User();
           user.name = name;
           db.Users.InsertOnSubmit(user);
           db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
        }
    }
