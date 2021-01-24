    using MySql.Data.MySqlClient;
            
    private const String SERVER = "1.1.1.1";         // Server IP
    private const String DATABASE = "abc";           // Date base name
    private const String TABLE = "test";             // Table name
    private const String UID = "user";               // Date base username
    private const String PASSWORD = "pass";          // Date base password
    private const byte SSLMODE = 0;                  // SSL mode
                    
    public static void InitializeDataBase()
    {                
    MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                    
    builder.Server = SERVER;
    builder.UserID = UID;
    builder.Password = PASSWORD;
    builder.Database = DATABASE;
    builder.SslMode = SSLMODE;
    //builder.CertificateFile = @"<Path_To_The_File>\client.pfx";
    //builder.CertificatePassword = "<Password_For_The_Cert>";
                    
    String connString = builder.ToString();
    builder = null;
                    
    dbConn = new MySqlConnection(connString);         
    }
    
    /*
                None    	0	Do not use SSL.
                Preferred	1	Use SSL, if server supports it. This option is only available for the classic protocol.
                Prefered	1	
                Required	2	Always use SSL. Deny connection if server does not support SSL. Do not perform server certificate validation. This is the default SSL mode when the same isn't specified as part of the connection string.
                VerifyCA	3	Always use SSL. Validate server SSL certificate, but different host name mismatch.
                VerifyFull	4	Always use SSL and perform full certificate validation.
    */
