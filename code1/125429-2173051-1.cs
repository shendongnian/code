    if (!UsersOnline.ContainsKey(u.GetUserId()))
    {
        if (User.ValidateUser(u.GetUserId(), u.GetPassword(), con))
        {
            lock (UsersOnline)
            {
                if (!UsersOnline.ContainsKey(u.GetUserId())
                {
                    UsersOnline.Add(u.GetUserId(), e.ClientSocket);
                    // ...
                }
            }
            /*CHANGE 1.2.10 00:14*/
        }
        else
        {
            server.BlockIp(e.ClientSocket);
            return;
        }
    }
