    interface IUser
    {
         int UserId { get; set; }
         string UserName { get; set; }
    }
    internal IQueryable<T> GetUsers<T>()
        where T : IUser, new()
    {
        var result = from u in db.Users
             select new T()
             {
                UserID = u.ID,
                UserName = u.Name
             };
        return result;
    }
