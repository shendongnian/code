    public IUser this[Guid userId]
    {
        get { return GetUser(userId); }
    }
    private IUser GetUser(Guid userId)
    {
        return (from u in _dataContext.Users 
                where u.Id == userId 
                select u).FirstOrDefault();
    }
