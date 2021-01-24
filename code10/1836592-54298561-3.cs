    string sql = "SELECT SUM(Liter) AS TotalLiter ... ";  // 2nd SQL example.
    using (var con = new SqlConnection("connection string"))
    using (var cmd = new SqlCommand(sql, con)) {
        con.Open();
        int total = (int)cmd.ExecuteScalar();
        ...
    }
