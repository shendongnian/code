    using (var conn = new SqlConnection(SQLConnectionString))
    {
        conn.Open();
        if (conn.State == ConnectionState.Open)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT [Col1] FROM [Table1] WHERE [Col2]='" + val2 + "'", conn);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
    
            if (dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count != 1)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO [Table1] ([Col1], [Col2]) VALUES ('" + val1 + "', '" + val2 + "')", conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
