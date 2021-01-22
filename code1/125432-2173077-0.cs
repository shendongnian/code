    if (!UsersOnline.ContainsKey(u.GetUserId()))
    {
        if (User.ValidateUser(u.GetUserId(), u.GetPassword(), con))
        {
            /*CHANGE 1.2.10 00:14*/
            lock (UsersOnline)
            {
                UsersOnline.Add(u.GetUserId(), e.ClientSocket);
