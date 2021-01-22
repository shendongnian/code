    public User CreateUser(string username, string password, UserDetails details)
    {
        if (Validator.isValid(details, username, password)) {
           // what happens when not valid
        }
    
        // create and return user
    }
