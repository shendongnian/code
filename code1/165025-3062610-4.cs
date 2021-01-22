    public void DoSomeWork(SqlCommand command)
    {
        SqlConnection conn = new SqlConnection(connString);
    
        conn.Open();
        command.Connection = conn;
        // Rest of the work here
     }
