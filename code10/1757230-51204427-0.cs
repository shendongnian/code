    [WebMethod(EnableSession = true)]
	public static int GetCollection(string lvl)
	{
    int success=0;
    string conn = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
    using (SqlConnection connection = new SqlConnection(conn))
        try
        {
            connection.Open();
            SqlCommand cmdCount = new SqlCommand("getDuplicate", connection);
            cmdCount.CommandType = CommandType.StoredProcedure;
            cmdCount.Parameters.AddWithValue("@ObjekatName", lvl);
            var count = (string)cmdCount.ExecuteScalar();
            if (count == null)
            {
                SqlCommand cmdProc = new SqlCommand("InsertObjekat", connection);
                cmdProc.CommandType = CommandType.StoredProcedure;
                cmdProc.Parameters.AddWithValue("@ObjekatName", lvl);                   
                cmdProc.ExecuteNonQuery();
                success= 1;
            }
            else
            {
               
            }
        }
        catch 
        {
        }
        finally
        {
            connection.Close();
        }
    return success;
    }
