    using MySql.Data.MySqlClient;
            
    private const String SERVER = "1.1.1.1";         // Server IP
    private const String DATABASE = "abc";           // Date base name
    private const String TABLE = "test";             // Table name
    private const String UID = "user";               // Date base username
    private const String PASSWORD = "pass";          // Date base password
                    
    public static void InitializeDataBase()
    {                
    MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                    
    builder.Server = SERVER;
    builder.UserID = UID;
    builder.Password = PASSWORD;
    builder.Database = DATABASE;
    builder.SslMode = MySqlSslMode.None;
    //builder.CertificateFile = @"<Path_To_The_File>\client.pfx";
    //builder.CertificatePassword = "<Password_For_The_Cert>";
                    
    String connString = builder.ToString();
    builder = null;
                    
    dbConn = new MySqlConnection(connString);         
    }    
