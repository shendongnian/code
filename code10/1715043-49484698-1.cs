    public class UserProvider : IUserProvider
    {
    	public UserInfo User {get; set;}
    }
    
    public class UserManager : IUserManager
    {
    	public UserManager(IDBContext db, IUserProvider provider, ... )
		{
			_context = db;
			_userProvider = provider;
			...
		}
		private IDBContext _context ;
		private IUserProvider _userProvider;
		
        // ... Some logic that fills _userProvider.UserInfo 
    }
    
    public class DBContext
    {
    	public DBContext(IUserProvider provider, ...)
		{
			_userProvider = provider;
			...
		}
		private IUserProvider _userProvider;
    	// ... Here you can use _userProvider.UserInfo
    }
