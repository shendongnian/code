    string connStr = @"YourConnectionString;";
    string cmd = @"SELECT SUBSTRING(ColumnA, 1, 2) AS ColumnA from YourSchema.YourTable";
    using (SqlConnection conn = new SqlConnection(connStr))
    {
        conn.Open();
        DataTable dt = new DataTable();
        //create data adapter from string with SQL command and SQL Connection object
        SqlDataAdapter da = new SqlDataAdapter(cmd, conn);
        
        //populate DataTable
        da.Fill(dt);
    }
