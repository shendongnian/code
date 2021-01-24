    public class UserManager : IUserManager
    {
    	public UserManager(IDBContext db, ... )
        {
			_context = db;
			...
        }
		private IDBContext _context ;
    	public UserInfo User {get; set;}
        // ... Some logic that fills User 
    }
    
    public class DBContext : IDBContext
    {
    	public DBContext(...)
		{
			...
		}
    	// ... Here you need UserInfo to filter.
    }
