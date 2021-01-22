    private void GetSearchResults(string machineID, string searchFileName)
    {
        DataTable dt = new DataTable();
        SqlConnection connection = new SqlConnection();
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["SumooHAgentDBConnectionString"].ConnectionString;
        connection.Open();
        SqlCommand sqlCmd = new SqlCommand("SELECT FileID, BuFileName FROM BackedUpFiles WHERE BuFileName Like @searchFileName AND MachineID=@machineID", connection);
        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
        sqlCmd.Parameters.AddWithValue("@machineID", machineID);
        sqlCmd.Parameters.AddWithValue("@searchFileName", String.Format("%{0}%",searchFileName);
        sqlDa.Fill(dt);
    }
