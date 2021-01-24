    public void StartListener()
    {                    
        var message = GetMessage(); 
        //process message in some way
        object[] args = { this, EventArgs.Empty };
        EventHandler notify = OnNotificationComplete;                
        this.BeginInvoke(notify, args);                     
    }
    private const int TimeoutStep = 2000;
    private const int MaxTimeout = 10000;
    private string GetMessage(int timeout = 0)
    {
        //prevent loop of endless retries
        if (timeout >= MaxTimeout)
        {
            //optional: define your own Exception class
            throw new MaxTimeoutException();
        }
        try
        {
            Thread.Sleep(timeout);
            return GetMessageFromDatabase();
        }
        catch (SqlException ex)
        {
            //log ex in debug mode at least               
            return GetMessage(timeout + TimeoutStep);
        }             
    }
    private string GetMessageFromDatabase()
    {
        string message = null;
        using (var connection = new SqlConnection(GetConnectionString()))
        {
            using (var command = new SqlCommand(GetListenerSQL(), connection))
            {
                connection.Open();
                command.CommandTimeout = NotificationTimeout;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        message = System.Text.ASCIIEncoding.ASCII.GetString((byte[])reader.GetValue(13));
                    }
                }
            }
        }
        return message;
    }
