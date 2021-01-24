    string sql = "SELECT ... ";
    using (var con = new SqlConnection("connection string"))
    using (var cmd = new SqlCommand(sql, con)) {
        con.Open();
        var reader = cmd.ExecuteReader();
        while (reader.Read()) {
            string cattle = reader.GetString(0);
            int total - reader.GetInt32(1);
            ...
        }
    }
