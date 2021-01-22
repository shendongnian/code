    if (!UsersOnline.ContainsKey(u.GetUserId()))
    {
        if (User.ValidateUser(u.GetUserId(), u.GetPassword(), con))
        {
            lock (UsersOnline)
            {
                // Note the additional check in case another thread
                // added this already
                if (!UsersOnline.ContainsKey(u.GetUserId())
                {
                    UsersOnline.Add(u.GetUserId(), e.ClientSocket);
                    // ...
                }
            }
        }
        else
        {
            server.BlockIp(e.ClientSocket);
            return;
        }
    }
