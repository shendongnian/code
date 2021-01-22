    public IDataReader ExecuteReader(string cmdTxt)    
    {        
        SqlConnection conn = new SqlConnection(...);
        SqlCommand cmd = null;
        try
        {
            cmd = new SqlCommand(cmdTxt, conn);
            conn.Open();                
            IDataReader reader = 
                cmd.ExecuteReader(CommandBehavior.CloseConnection);           
            cmd.Dispose();
            return reader;
        }
        catch
        {
            if (cmd != null) cmd.Dispose();
            conn.Close();
            throw;
        }
    }
