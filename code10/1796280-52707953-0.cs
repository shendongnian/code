    public async Task<Users> Register(Users users, string password)
    {
        byte[] passwordHash, passwordSalt;
        CreatePasswordHash(password, out passwordHash, out passwordSalt);
        users.PasswordHash = Convert.ToBase64String(passwordHash);
        users.PasswordSalt = Convert.ToBase64String(passwordSalt);
        //save into database
        await _context.Users.AddAsync(users);
        await _context.SaveChangesAsync();
        return users;
    }
