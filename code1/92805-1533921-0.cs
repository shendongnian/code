    // LogonType = 8		// LOGON32_LOGON_NETWORK_CLEARTEXT
    // LogonProvider = 0	// LOGON32_PROVIDER_DEFAULT
    
    [DllImport ( "advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true )]
    private static extern bool LogonUser( string userName, string domain,
    	string password, int logonType, int logonProvider, ref IntPtr accessToken );
    
    [DllImport ( "kernel32.dll", SetLastError = true )]
    private static extern bool CloseHandle( IntPtr handle );
    
    private static readonly object Locker = new Object ();
        
    private static WindowsIdentity GetIdentity( string username, string domain, string password )
    {
    	lock ( Locker )
    	{
    		IntPtr token = IntPtr.Zero;
    		if ( LogonUser ( username, domain, password,
    			(int) LogonType, (int) LogonProvider, ref token ) )
    		{
    			// using the token to create an instance of WindowsIdentity class
    			var identity = new WindowsIdentity ( token );
    			CloseHandle ( token ); // the WindowsIdentity object duplicates this token internally
    			return identity;
    		}
    
    		throw new SecurityException ( string.Format (
    			"Invalid username/password (domain: '{0}', username: '{1}')",
    			domain, username ) );
    	}
    }
    public static T ExecuteAction<T>( string username, string domain, string password,
    	Func<T> contextAction )
    {
    	var identity = GetIdentity ( username, domain, password );
    	var context = identity.Impersonate ();
    	try
    	{
    
    		return contextAction ();
    	}
    	finally
    	{
    		context.Undo ();
    		context.Dispose ();
    	}
    }
