    public void Storetxt(String txt)
    {
        //connection to the database
        string connection = "Data Source=.\\sqlexpress2005;Initial Catalog=PtsKuratlas;Integrated Security=True";
        SqlConnection conn = null;
        SqlCommand cmd = null;
        try
        {
            conn = new SqlConnection(connection);
            cmd = new SqlCommand("INSERT INTO gti_analytics (Links) VALUES (@Link)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Link", txt);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch{//handle exceptions}
        finally
        {
            if (cmd != null) cmd.Dispose();
            if (conn != null) 
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Dispose();
            }
        }
    }
