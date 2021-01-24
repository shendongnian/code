    public async Task<Users> Login(string username, string password)
    {
        //returns the username from the databse
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
        if (user == null)
        {
            return null;
        }
        if (!VerifyPasswordHash(password, Convert.FromBase64String(user.PasswordHash),
            Convert.FromBase64String(user.PasswordSalt)))
            return null;
        return user;
    }
