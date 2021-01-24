    public DataSet GetData()
    {
        //Move where you declare output ot here
        DataSet output = new DataSet();
        try
        {
            SqlConnection conn = new SqlConnection(connectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
    
            String sql = "Select top 100 * from SEQUENCE";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            
    
            adapter.Fill(output);
            conn.Close();
    
                 
    
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(),
                       "ServerControlScript", ex.Message, true);
    
            return (null);
    
        }
         //And move the return to here 
         return output;
    }
    
    
    
        //Should just need this to display the data
        GridViewOutput.DataSource = GetData();
        GridViewOutput.DataBind();
