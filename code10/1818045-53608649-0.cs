    string AuthorizeUser(string userName, string password)
    {
       var users= new Dictionary<string, string>()
       {
           {"Guest", null},
           {"Admin", "admin"},
           {"Limited", "limited"}
       };
       if (users.TryGetValue(userName, out var storedPassword)
       {
            if (storedPassword == null
                password == storedPassword)
                return userName.ToUpperInvariant();
            return "UNKNOWN";        
       }
    } 
