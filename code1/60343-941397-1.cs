    public IDataReader ExecuteReader(string cmdTxt)    
    {        
        SqlConnection conn = new SqlConnection(...);
        try
        {
            SqlCommand cmd = new SqlCommand(cmdTxt, conn);
            conn.Open();                
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);           
        }
        catch
        {
            conn.Close();
            throw;
        }
    }
