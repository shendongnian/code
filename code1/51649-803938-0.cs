    public IEnumerable<string> GetStuff(string connectionString)
    {
        DataTable table = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            string commandText = "GetStuff";
            using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(table);
            }
    
        }
        foreach(DataRow row in table.Rows)
        {
            yeild return row["myImportantColumn"].ToString();
        }
    }
