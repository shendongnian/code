    DataTable resultTable = new DataTable();
 
    using(SqlConnection con = new SqlConnection("your connection string here"))
    {
        string sqlStmt = "SELECT (columns) FROM dbo.YourTable WHERE (condition)";
        using(SqlCommand cmd = new SqlCommand(sqlStmt, con))
        {
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(resultTable);
        }
    }
