    public void FileToTable()
    {
        TraceServer reader = new TraceServer();
    
        ConnectionInfoBase ci = new SqlConnectionInfo("localhost");
        ((SqlConnectionInfo)ci).UseIntegratedSecurity = true;
                
        reader.InitializeAsReader(ci, @"Standard.tdf");
    
        int eventNumber = 0;
    
        while (reader.Read())
        {
            Console.Write( "{0}\n", reader.GetValue(0).ToString() );
        }
        reader.Close();        
    }
