    string CommandText = "UPDATE x SET k = @k WHERE NumberOfOrders > 0";
    using (SqlConnection conn = new SqlConnection(My.Settings.DatabaseConnection)) {
        using (SqlCommand cmd = new SqlCommand(CommandText, conn)) {
            cmd.Parameters.AddWithValue("@k", "bla");
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
