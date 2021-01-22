    public class SecurityManager<T,TPersistenceProvider,TUserProvider> 
        where T : class
        where TPersistenceProvider : ISecurityPersistenceProvider
        where TUserProvider : ISecurityUserProvider<T>
    {
        private readonly ISecurityPersistenceProvider persistenceProvider;
        private readonly ISecurityUserProvider<T> userProvider;
        // NOTE this constant is used to validate the validity of the cookie (see below)
        private const int CookieParameterCount = 3;
        
        public SecurityManager( ISecurityPersistenceProvider persistenceProvider, ISecurityUserProvider<T> userProvider )
        {
             this.persistenceProvider = persistenceProvider;
             this.userProvider = userProvider;
        }
        
        #region Properties
        protected ISecurityPersistenceProvider PersistenceProvider
        {
            get { return persistenceProvider; }
        }
        protected ISecurityUserProvider<T> UserProvider
        {
            get { return userProvider; }
        }
        public IIdentity CurrentIdentity
        {
            get { return Thread.CurrentPrincipal.Identity; }
        }
        public bool IsAuthenticated
        {
            get
            {
                IPrincipal principal = Thread.CurrentPrincipal;
                return principal != null && principal.Identity != null && principal.Identity.IsAuthenticated;
            }
        }
        public bool IsInRole( string roleName )
        {
            IPrincipal principal = Thread.CurrentPrincipal;
            return IsAuthenticated && principal.IsInRole( roleName );
        }
        public string UserName
        {
            get { return IsAuthenticated ? CurrentIdentity.Name : ""; }
        }
        #endregion
        #region Authentication
        public AuthenticationResult Authenticate( string userName, string password, bool persistent, string visitorAddress )
        {
            return Authenticate( null, userName, password, persistent, visitorAddress );
        }
        public AuthenticationResult Authenticate( string customer, string userName, string password, bool persistent, string visitorAddress )
        {
            AuthenticationResult result = ValidateInput( userName, password );
            if( ! result.Success )
                return result;
            string passwordHash = GetCryptographicHash( password );
            T user = userProvider.AuthenticateUser( customer, userName, passwordHash );
            if( user == null )
                return new AuthenticationResult( false, "Unable to login using the specified credentials.", null );
            if( ! IsAuthorizedVisitor( user, visitorAddress ) )
                return new AuthenticationResult( false, "Credentials do not allow login from your current IP address.", null );
            CurrentPrincipal = new CodeworksPrincipal<T>( userName, userProvider.GetRoles( user ), user );
            // remember to change CookieParameterCount if you change parameter count here
            string cookieData = String.Format( "{0}|{1}|{2}", CurrentIdentity.Name, customer, CurrentPrincipal.AllRoles );
            persistenceProvider.SetAuthCookie( 1, userName, DateTime.Now.AddMonths( 1 ), persistent, cookieData );
            // TODO create an audit log entry for the current request
            return new AuthenticationResult( true, null, null );
        }
        private AuthenticationResult ValidateInput( string login, string password )
        {
            var result = new AuthenticationResult( true, "Invalid or missing credentials." );
            if( String.IsNullOrEmpty( login ) )
            {
                result.Success = false;
                result.Errors.Add( "login", "You must specify an alias or email address." );
            }
            if( String.IsNullOrEmpty( password ) )
            {
                result.Success = false;
                result.Errors.Add( "password", "You must specify a password." );
            }
            // TODO add message to inform users of other requirements.
            return result;            
        }
        #endregion
        #region Cookie Authentication
        public void CookieAuthenticate( string visitorAddress )
        {
            HttpCookie cookie = persistenceProvider.GetAuthCookie();
            if( cookie != null )
            {
                string userName;
                string userData = persistenceProvider.GetAuthCookieValue( out userName );
                string[] cookieData = userData.Split( '|' );
                // extract data from cookie
                bool isValid = cookieData.Length == CookieParameterCount && 
                               ! string.IsNullOrEmpty( cookieData[ 0 ] ) &&
                               cookieData[ 0 ] == userName &&
                               IsAuthorizedVisitor( cookieData[ 1 ], cookieData[ 0 ], visitorAddress );
                if( isValid )
                {
                    string customer = cookieData[ 1 ];
                    string[] roles = cookieData[ 2 ].Split( ',' );
                    T user = userProvider.GetUser( customer, userName );
               
                    CurrentPrincipal = new CodeworksPrincipal<T>( userName, roles, user );
                }
            }
        }
        #endregion
        #region Logout
        public void Logout()
        {
            // logout the current user
            if( HttpContext.Current.Request.IsAuthenticated || CurrentPrincipal != null )
            {
                long address = GetAddressFromString( HttpContext.Request.UserHostAddress );
                // TODO add audit log entry
                // sign out current user
                persistenceProvider.RemoveAuthCookie();
                CurrentPrincipal = null;
            }
        }
        #endregion
        #region VisitorAddress Checks
        public long GetAddressFromString( string address )
        {
            IPAddress ipAddress;
            if( IPAddress.TryParse( address, out ipAddress ) )
            {
                byte[] segments = ipAddress.GetAddressBytes();
                long result = 0;
                for( int i = 0; i < segments.Length; i++ )
                {
                    result += segments[ i ] << (i * 8);
                }
                return result;
            }
            return long.MaxValue;
        }
        public bool IsAuthorizedVisitor( string customer, string userName, string visitorAddress )
        {
            return IsAuthorizedVisitor( customer, userName, GetAddressFromString( visitorAddress ) );
        }
        public bool IsAuthorizedVisitor( string customer, string userName, long visitorAddress )
        {
            T user = userProvider.GetUser( customer, userName );
            return IsAuthorizedVisitor( user, visitorAddress );
        }
        public bool IsAuthorizedVisitor( T user, string visitorAddress )
        {
            return IsAuthorizedVisitor( user, GetAddressFromString( visitorAddress ) );
        }
        public bool IsAuthorizedVisitor( T user, long visitorAddress )
        {
            if( user == null || visitorAddress == 0 )
                return false;
            if( user.Hosts.Count == 0 )
                return true;
            foreach( Host host in user.Hosts )
            {
                if( IsAuthorizedVisitor( host.HostAddress, host.HostMask, visitorAddress ) )
                    return true;
            }
            return true;
        }
        public bool IsAuthorizedVisitor( long allowedAddress, long allowedMask, long visitorAddress )
        {
            long requireMask = allowedAddress & allowedMask;
            return (visitorAddress & requireMask) == requireMask;
        }
        #endregion
        #region Cryptographic Helpers
        public static string GetCryptographicHash( string password )
        {
            SHA256 hash = SHA256.Create();
            byte[] input = Encoding.UTF8.GetBytes( password );
            byte[] output = hash.ComputeHash( input );
            return Convert.ToBase64String( output );
        }
        #endregion
    }
