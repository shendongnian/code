    string sql = "SELECT Cattle, SUM(Liter) AS TotalLiter ... "; // 1st SQL example.
    using (var con = new SqlConnection("connection string"))
    using (var cmd = new SqlCommand(sql, con)) {
        con.Open();
        var reader = cmd.ExecuteReader();
        while (reader.Read()) {
            string cattle = reader.GetString(0); // 1st column
            int total = reader.GetInt32(1); // 2nd column
            ...
        }
    }
