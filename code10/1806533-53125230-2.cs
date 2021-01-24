    public string GetCartStringForEMail(string email)
    {
        const string sql = "SELECT menu_name, menu_quantity FROM cart WHERE email=@email";
        string connectionString =
            ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        using (var conn = new SqlConnection(connectionString))
        using (var cmd = new SqlCommand(sql, conn)) {
            var sb = new StringBuilder();
            cmd.Parameters.AddWithValue("@email", email);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                sb.Append(reader.GetString(0))
                    .Append(", ")
                    .AppendLine(reader.GetInt32(1).ToString());
            }
            return sb.ToString();
        }
    }
