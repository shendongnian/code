    bool AuthorizeUser(string userName, string password)
    {
        var users = new Dictionary<string, string>()
        {
            {"GUEST", null},
            {"ADMIN", "admin"},
            {"LIMITED", "limited"}
        };
        var upperInvariantUserName = userName.ToUpperInvariant();
        if (users.TryGetValue(upperInvariantUserName,
            out var storedPassword))
        {
            if (storedPassword == null ||
                password == storedPassword)
                return true;
        }
        return false;        
    } 
