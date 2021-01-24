    public static bool EmailExists(string Email)
    {        
        using (var db = new Models.UserRegistrationPasswordsEntities1()) {
            return db.Users.Any(c => c.userEmail == Email);
        }       
    }
