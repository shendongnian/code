    string connectionString = @“Provider = Microsoft.Jet.OLEDB.4.0; " + 
                              @"Data Source = C:\data\northwind.mdb; " +
                              @"User Id = guest; Password = abc123”
    
    using (OleDbConnection oleDbConnection = New OleDbConnection())
    {
        oleDbConnection.ConnectionString = connectionString;
        oleDbConnection.Open();
        ...
    }
