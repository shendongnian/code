    user = SetUserProperties(user);
    ...
    public User SetUserProperties(User user)
    {
        if(user == null) 
        {
            user = new User();
        }
        user.Firstname = "blah";
        ....
        return user;
    }
