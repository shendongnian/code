    string name = user.Fullname;
    if(!string.IsNullOrEmpty(user.Nickname))
    {
        name = user.Nickname;
    }
