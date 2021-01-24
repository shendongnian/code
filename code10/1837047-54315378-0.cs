    public IEnumerable<IUser> GetUsers()
    {
        using (var db = new SiteContext(_connectionString))
        {
            return db.Users;
        }
    }
