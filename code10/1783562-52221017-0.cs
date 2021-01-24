    [HttpGet]
    [Route("api/users/name")]
    public IEnumerable<User> GetByFirstName(string FirstName = null, string LastName = null)
    { 
        var users = Enumerable.Empty<User>();
        if (FirstName != null && LastName != null)
            users = _context.Users.Where(u => (u.FirstName == FirstName) && (u.LastName == LastName));
        else if (FirstName != null)
            users = _context.Users.Where(u => u.FirstName == FirstName);
        else if (LastName != null)
            users = _context.Users.Where(u => u.LastName == LastName);
    
        return users;
    }
