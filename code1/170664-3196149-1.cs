    public DataSet GetData()
    {
        SqlDataReader reader;
        string connstr = your conn string;
        SqlConnection conn = new SqlConnection(connstr);
        DataTable st = new DataTable();
        DataSet ds = new DataSet();
        try
        {                   
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Your select query";
            cmd.Connection = conn;
            conn.Open();
                   
            reader = cmd.ExecuteReader();
            dt.Load(reader);
            ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            // your exception handling 
        }
        finally
        {
            reader.Close();
            reader.Dispose();
            conn.Close();
            conn.Dispose();
        }    
        return ds;
    }
