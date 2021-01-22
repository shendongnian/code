    string sql = "INSERT INTO Your_Table (Your_Column) VALUES (@YourParam)";
    using (SqlConnection conn = new SqlConnection("..."))
    using (SqlCommand cmd = new SqlCommand(sql, conn))
    {
        cmd.Parameters.Add("@YourParam", SqlDbType.DateTime).Value = yourDate;
        conn.Open();
        cmd.ExecuteNonQuery();
    }
