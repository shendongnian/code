    public class UserRepo : IDisposable
    {
        public Lazy<AppDataContext> _db = new Lazy<AppDataContext>(() => new AppDataContext());
        public IQueryable<User> Get() => _db.Value.Users.AsQueryable();
        public IList<User> GetAll() => _db.Value.Users.ToList();
        public void Dispose()
        {
            if (_db.IsValueCreated)
                _db.Value.Dispose();
        }
    }
	
