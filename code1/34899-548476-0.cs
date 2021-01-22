    public bool ValidateApplicationUser(string userName, string password)
    {
        //Get Database Context
        var AuthContext = new DataClasses1DataContext();
        //We Are Only Going To Select UserId, Notice The Password .ToLower Is Removed (for security)
        var query = from c in AuthContext.Users
                    where (c.Username == userName.ToLower() && c.Password == password)
                    select c;
        if (query.Count() != 0) {
           return true;
        }
        return false;
    }
