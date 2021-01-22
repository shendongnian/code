    public interface ISecurityUserProvider<T> where T : class
    {
        T AuthenticateUser( string customer, string userName, string passwordHash );
        T GetUser( string customer, string userName );
    	string[] GetRoles( T user );
    }
