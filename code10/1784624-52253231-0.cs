    try
    {
        OleDbConnection conn = new OleDbConnection(connectionString);
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        String OleDb = "SELECT [Bank], [Amount] FROM [BankDetails]";
        using (OleDbCommand cmd = new OleDbCommand(OleDb, conn))
        {
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Response.Write("" + reader.GetString(0));
                }
            }
        }
    }
    catch (Exception ex)
    {
        Response.Write(ex);
    }
