    public static class Queries
    {
    	private static readonly Func<MyDatContext, string, IQueryable<User>> GetUserCompiled
    		= CompiledQuery.Compile<MyDataContext, string, IQueryable<User>>
    			(context, username) => context.Users.Where(u => u.Username.Equals(username));
    
    	public static User GetUser(string username) {
    		using (var context = new MyDataContext()) {
    			return GetUserCompiled(context, username).SingleOrDefault();
    		}
        }
    }
