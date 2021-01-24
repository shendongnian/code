enter code here
    public static void Main(string[] args)   
    {
        bool flag = true;
        string server = "127.0.0.1";
        string port = "5432";
        string database = "postgres";
        string uid = "postgres";
        string password = "postgres";
        string connStr;
        // the connection string
        connStr = $"SERVER = {server}; Port = {port};  DATABASE = {database}; User Id = 
        {uid}; PASSWORD = {password};"; 
        NpgsqlConnection notificationConnection;
        NpgsqlConnectionStringBuilder csb = new NpgsqlConnectionStringBuilder(connStr);
            
        try
        {
            notificationConnection = new NpgsqlConnection(connStr);
            notificationConnection.Open();
            if (notificationConnection.State != System.Data.ConnectionState.Open)
            {
                WriteLine("Connection to database failed");
                return;
            }
            using (NpgsqlCommand cmd = new NpgsqlCommand($"LISTEN {notificationName}", 
                   notificationConnection))
            {
                cmd.ExecuteNonQuery();
            }
            notificationConnection.Notification += PostgresNotification;
            notificationConnection.WaitAsync();
        }   
        catch(Exception ex)
       {
           WriteLine($"Exception thrown with message : {ex.Message}");
           return;
       }
            
       //  wait forever, press enter key to exit program  
       ReadLine();
    
       // stop the db notifcation
       notificationConnection.Notification -= PostgresNotification;
       using (var command = new NpgsqlCommand($"unlisten {notificationName}", 
          notificationConnection))
       {
           command.ExecuteNonQuery();
       }
           notificationConnection.Close();
    }
    //  the callback method that handles notification
    static void PostgresNotification(object sender, NpgsqlNotificationEventArgs e)
    {
         WriteLine("Notification Received");
    }
