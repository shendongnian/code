    protected SqlCommand GetNewCmd()
    {
        SqlCommand objCmd = new SqlCommand();
        objCmd.Connection = new SqlConnection(this.ConnString);
        objCmd.CommandType = CommandType.StoredProcedure;
        return objCmd;
    
    }
    
    protected SqlCommand GetNewCmd(string CmdText)
    {
        SqlCommand objCmd = new SqlCommand(CmdText, 
                                 new SqlConnection(this.ConnString));
        objCmd.CommandType = CommandType.StoredProcedure;
        return objCmd;
    }
    
    protected DataTable GetTable(SqlCommand objCmd)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
    
        try
        {
            da.SelectCommand = objCmd;
            da.Fill(dt);
    
            dt.DefaultView.AllowNew = false;
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw;
        }
        finally
        {
            Close(objCmd);
            da.Dispose();
            da = null;
    
        }
    
        return dt;
    
    }
